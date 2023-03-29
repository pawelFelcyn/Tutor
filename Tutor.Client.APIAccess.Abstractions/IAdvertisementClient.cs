using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions;

public interface IAdvertisementClient
{
    Task<APIResponse<AdvertisementDetailsDto>> CreateAsync(CreateAdvertisementDto dto);
}
