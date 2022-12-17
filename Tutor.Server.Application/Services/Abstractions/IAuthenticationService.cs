using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services.Abstractions;

public interface IAuthenticationService
{
    Task RegisterAsync(RegisterUserDto dto);
    Task<string> GetTokenAsync(LoginDto dto);
}
