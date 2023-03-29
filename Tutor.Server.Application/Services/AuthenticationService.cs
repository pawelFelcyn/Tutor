using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Application.Authentication;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Application.Services;

internal class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly IUserContextService _userContextService;

    public AuthenticationService(IUserRepository repository, IMapper mapper,
        IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings,
        IUserContextService userContextService)
    {
        _repository = repository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _authenticationSettings = authenticationSettings;
        _userContextService = userContextService;
    }

    public async Task RegisterAsync(RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
        await _repository.AddAsync(user);
    }

    public async Task<string> GetTokenAsync(LoginDto dto)
    {
        var user = await _repository.GetByEmailAsync(dto.Email);
        var authResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (authResult != PasswordVerificationResult.Success)
        {
            throw new InvalidPasswordException();
        }

        return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
        var claims = GetClaims(user);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddDays(_authenticationSettings.JwtExpireDays);
        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
            claims, signingCredentials: credentials, expires: expires);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private IEnumerable<Claim> GetClaims(User user)
    {
        return new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };
    }

    public async Task<string> RefreshTokenAsync()
    {
        var userId = _userContextService.UserId;
        var user = await _repository.GetByIdAsync(userId.Value);
        return GenerateToken(user);
    }
}
