using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class LoginClient : APIClient, ILoginClient
{
    public LoginClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<APIResponse> LoginAsync(LoginDto dto) => PostAsync("api/authentication/login", dto);
}
