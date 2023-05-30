using Microsoft.AspNetCore.Authorization;

namespace Tutor.Server.Application.Authentication
{
    public interface ISpecyfiedRequirementHandler
    {
        public Task HandleRequirementPublicAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement);
    }

    public abstract class SpecyfiedRequirementHandler<T> : AuthorizationHandler<T>/*, ISpecyfiedRequirementHandler*/ where T : IAuthorizationRequirement
    {
        public Task HandleRequirementPublicAsync(AuthorizationHandlerContext context, T requirement) => HandleRequirementAsync(context, requirement);
    }
}
