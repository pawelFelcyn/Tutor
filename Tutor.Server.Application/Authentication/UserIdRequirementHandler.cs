using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Server.Application.Authentication
{
    public class UserIdRequirementHandler : SpecyfiedRequirementHandler<UserIdRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIdRequirement requirement)
        {
            if (context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value == requirement.RequiredId.ToString())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
