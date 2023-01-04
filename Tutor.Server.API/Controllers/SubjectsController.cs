using Microsoft.AspNetCore.Mvc;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectService _service;

    public SubjectsController(ISubjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAll()
    {
        var subjects = await _service.GetAll();
        return Ok(subjects);
    }
}
