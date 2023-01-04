using Microsoft.AspNetCore.Authorization;

namespace Tutor.Server.Application.Authentication;

public interface IAuthorizationContextProvider
{
    AuthorizationHandlerContext CreateContext(IEnumerable<IAuthorizationRequirement> requirements, object resource);
}
