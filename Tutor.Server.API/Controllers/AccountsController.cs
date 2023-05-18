using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service; 
        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<UserDetailsDto>> Update([FromBody] UpdateAccountDto dto)
        {
            var details = await _service.UpdateAsync(dto);
            return Ok(details);
        }
    }
}
