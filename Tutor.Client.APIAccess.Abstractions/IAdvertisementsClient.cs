using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions;

public interface IAdvertisementsClient
{
    Task<APIResponse<PagedResult<AdvertisementDto>>> GetAdvertisementsAsync();
}
