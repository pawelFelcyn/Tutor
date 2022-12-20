using Microsoft.AspNetCore.Authorization;

namespace Tutor.Server.Application.Authentication;

internal static class AuthorizationContextProviderExtensions
{
    public static AuthorizationHandlerContext CreateContext(this IAuthorizationContextProvider provider, IAuthorizationRequirement requirement)
    {
        NullCheck(provider);
        return provider.CreateContext(new IAuthorizationRequirement[] {requirement}, null);
    }

    private static void NullCheck(IAuthorizationContextProvider provider)
    {
        if (provider is null)
        {
            throw new ArgumentNullException(nameof(provider));
        }
    }
}
