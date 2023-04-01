using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class LoginClient : APIClient, ILoginClient
{
    public LoginClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<APIResponse<LoginResponseDto>> LoginAsync(LoginDto dto) 
        => PostAsync<LoginResponseDto>("api/authentication/login", dto);
}
