using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions;

public interface IRegistrationClient
{
    Task<APIResponse> RegisterAsync(RegisterUserDto dto);
}
