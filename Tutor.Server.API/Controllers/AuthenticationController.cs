using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> Register([FromBody] RegisterUserDto dto)
        {
            var response = await _service.RegisterAsync(dto);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto dto)
        {
            var loginResponse = await _service.GetLoginResponseAsync(dto);
            return Ok(loginResponse);
        }

        [HttpGet("refreshToken")]
        [Authorize]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var token = await _service.RefreshTokenAsync();
            return Ok(token);
        }
    }
}
