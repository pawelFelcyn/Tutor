using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sieve.Extensions.MethodInfoExtended;

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
