using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions;

public interface ILoginClient
{
    Task<APIResponse> LoginAsync(LoginDto dto);
}
