using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions.Extensions;

public static class AdvertisementClientExtensions
{
    public static Task<APIResponse<PagedResult<AdvertisementDto>>> GetAllAsync(this IAdvertisementClient client, 
        Action<AdvertisementsSieveModel> sieveBuilder)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        var sieve = new AdvertisementsSieveModel();
        sieveBuilder?.Invoke(sieve);
        return client.GetAllAsync(sieve);
    }
}
