using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Server.Application.Authentication
{
    public class GroupAuthorizationHandler : IAuthorizationHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public GroupAuthorizationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (var requirement in context.Requirements)
            {
                if (!(requirement is Requirement customRequirement))
                {
                    continue;
                }

                var handler = _serviceProvider.GetService(customRequirement.GetHandlerType());
                var method = handler.GetType().GetMethod("HandleRequirementPublicAsync");
                method?.Invoke(handler, new object[] { context, requirement });
            }

            return Task.CompletedTask;
        }
    }
}
