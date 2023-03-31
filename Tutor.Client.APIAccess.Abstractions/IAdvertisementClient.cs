using Sieve.Models;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions;

public interface IAdvertisementClient
{
    Task<APIResponse<AdvertisementDetailsDto>> CreateAsync(CreateAdvertisementDto dto);
    Task<APIResponse<PagedResult<AdvertisementDto>>> GetAllAsync(AdvertisementsSieveModel? sieve);
    Task<APIResponse<AdvertisementDetailsDto>> GetByIdAsync(Guid id);
}
