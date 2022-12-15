using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services;

internal class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthenticationService(IUserRepository repository, IMapper mapper,
        IPasswordHasher<User> passwordHasher)
    {
        _repository = repository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task RegisterAsync(RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
        await _repository.AddAsync(user);
    }
}
