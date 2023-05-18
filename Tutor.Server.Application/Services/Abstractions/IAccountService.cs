using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services.Abstractions;

public interface IAccountService
{
    Task<UserDetailsDto> UpdateAsync(UpdateAccountDto dto);
}
