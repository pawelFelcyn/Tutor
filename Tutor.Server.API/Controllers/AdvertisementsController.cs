using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertisementsController : ControllerBase
{
    private readonly IAdvertisementService _service;

    public AdvertisementsController(IAdvertisementService service)
	{
		_service = service;
	}

	[HttpPost]
	[Authorize]
	public async Task<ActionResult<AdvertisementDetailsDto>> Create([FromBody] CreateAdvertisementDto dto)
	{
		var advertisement = await _service.CreateAsync(dto);
		return Created($"api/adverticements/{advertisement.Id}", advertisement);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> Get([FromRoute] Guid id)
	{
		var advertisement = await _service.GetByIdAsync(id);
		return Ok(advertisement);
	}

	[HttpGet]
	public async Task<ActionResult<PagedResult<AdvertisementDto>>> GetAll([FromQuery]AdvertisementsSieveModel query)
	{
		var advertisemetns = await _service.GetAllAsync(query);
		return Ok(advertisemetns);
	}

	[HttpDelete("{id}")]
	[Authorize]
	public async Task<ActionResult> Delete([FromRoute] Guid id)
	{
		await _service.DeleteAsync(id);
		return NoContent();
	}

	[HttpPatch("{id}")]
	[Authorize]
	public async Task<ActionResult<AdvertisementDetailsDto>> Update([FromRoute] Guid id, [FromBody] UpdateAdvertisementDto dto)
	{
		var advertisement = await _service.UpdateAsync(id, dto);
		return Ok(advertisement);
	}
}
