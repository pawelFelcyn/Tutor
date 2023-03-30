using Sieve.Models;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services.Abstractions;

public interface IAdvertisementService
{
    Task<AdvertisementDetailsDto> CreateAsync(CreateAdvertisementDto dto);
    Task<AdvertisementDetailsDto> GetByIdAsync(Guid id);
    Task<PagedResult<AdvertisementDto>> GetAllAsync(AdvertisementsSieveModel query);
    Task DeleteAsync(Guid id);
    Task<AdvertisementDetailsDto> UpdateAsync(Guid id, UpdateAdvertisementDto dto);
}
