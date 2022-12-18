using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Application.Services;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IAdvertisementService, AdvertisementService>();
        services.AddScoped<IUserContextService, UserContextService>();

        return services;
    }
}
