using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class RegistrationClient : APIClient, IRegistrationClient
{
    public RegistrationClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<APIResponse> RegisterAsync(RegisterUserDto dto) => PostAsync("api/authentication/register", dto);
}
