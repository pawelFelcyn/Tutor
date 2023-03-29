using Tutor.Client.APIAccess.Abstractions;

namespace Tutor.Client.APIAccess;

internal class RefreshTokenClient : APIClient, IRefreshTokenClient
{
    public RefreshTokenClient(HttpClient httpClient, BearerTokenFactory bearerTokenFactory) 
        : base(httpClient, bearerTokenFactory)
    {
    }

    public Task<APIResponse> RefreshTokenAsync() => GetAsync("api/authentication/refreshToken");
}
