using System.Security.Claims;

namespace Tutor.Server.Application.Services.Abstractions;

public interface IUserContextService
{
    public ClaimsPrincipal User { get; }
    public Guid? UserId { get; }
}
