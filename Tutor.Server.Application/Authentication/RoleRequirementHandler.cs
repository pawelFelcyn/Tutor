using Microsoft.AspNetCore.Authorization;

namespace Tutor.Server.Application.Authentication;

public class RoleRequirementHandler : SpecyfiedRequirementHandler<RoleRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        if (context.User.IsInRole(requirement.Role))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
