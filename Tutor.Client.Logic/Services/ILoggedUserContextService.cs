using Tutor.Shared.Dtos;

namespace Tutor.Client.Logic.Services;

public interface ILoggedUserContextService
{
    UserDetailsDto LoggedInUser { get; set; }
}
