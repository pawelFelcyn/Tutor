using Microsoft.AspNetCore.Authorization;
using Tutor.Server.Application.Services.Abstractions;

namespace Tutor.Server.Application.Authentication;

internal class AuthorizationContextProvider : IAuthorizationContextProvider
{
    private readonly IUserContextService _userContextService;

    public AuthorizationContextProvider(IUserContextService userContextService)
    {
       _userContextService = userContextService;
    }

    public AuthorizationHandlerContext CreateContext(IEnumerable<IAuthorizationRequirement> requirements, object resource)
    {
        return new(requirements, _userContextService.User, resource);
    }
}
