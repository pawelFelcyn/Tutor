using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Tutor.Server.Application.Services.Abstractions;

namespace Tutor.Server.Application.Services;

internal class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;

    public Guid? UserId => User is null ? null : Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
}
