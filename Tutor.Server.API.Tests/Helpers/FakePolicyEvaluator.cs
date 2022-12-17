using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Tutor.Server.API.Tests.Helpers;

public class FakePolicyEvaluator : IPolicyEvaluator
{
    public ClaimsIdentity? ClaimsIdentity { get; set; }

    public Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
    {
        var claimsPrincipal = new ClaimsPrincipal();

        if (ClaimsIdentity != null)
        {
            claimsPrincipal.AddIdentity(ClaimsIdentity);
        }

        var ticket = new AuthenticationTicket(claimsPrincipal, "test");
        var result = AuthenticateResult.Success(ticket);

        return Task.FromResult(result);
    }

    public Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy, AuthenticateResult authenticationResult, HttpContext context, object? resource)
    {
        var result = PolicyAuthorizationResult.Success();

        return Task.FromResult(result);
    }
}
