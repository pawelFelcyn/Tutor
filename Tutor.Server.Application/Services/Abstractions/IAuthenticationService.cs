using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services.Abstractions;

public interface IAuthenticationService
{
    Task<LoginResponseDto> RegisterAsync(RegisterUserDto dto);
    Task<LoginResponseDto> GetLoginResponseAsync(LoginDto dto);
    Task<string> RefreshTokenAsync();
}
