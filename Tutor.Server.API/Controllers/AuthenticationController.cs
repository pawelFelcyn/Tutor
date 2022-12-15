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
        public async Task<ActionResult> Register([FromBody] RegisterUserDto dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }
    }
}
