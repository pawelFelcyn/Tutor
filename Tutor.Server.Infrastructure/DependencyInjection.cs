using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Infrastructure.Helpers;
using Tutor.Server.Infrastructure.Repositories;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Server.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailValidationHelper, EmailValidationHelper>();

            return services;
        }
    }
}
