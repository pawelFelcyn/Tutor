namespace Tutor.Client.APIAccess.Abstractions;

public interface IRefreshTokenClient
{
    Task<APIResponse> RefreshTokenAsync();
}
