using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class AdvertisementClient : APIClient, IAdvertisementClient
{
    public AdvertisementClient(HttpClient httpClient, BearerTokenFactory bearerTokenFactory) 
        : base(httpClient, bearerTokenFactory)
    {
    }

    public Task<APIResponse<AdvertisementDetailsDto>> CreateAsync(CreateAdvertisementDto dto)
        => PostAsync<AdvertisementDetailsDto>("api/advertisements", dto);
}
