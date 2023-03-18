using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Application.Authentication;
using Tutor.Server.Application.Helpers;
using Tutor.Server.Application.Services;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Application.Sieve;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Helpers.Abstractions;

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
        services.AddScoped<ISubjectService, SubjectsService>();
        services.AddScoped<IAuthorizationContextProvider, AuthorizationContextProvider>();
        services.AddScoped<IAuthorizationHandler, GroupAuthorizationHandler>();
        services.AddScoped<AuthorizationHandler<RoleRequirement>, RoleRequirementHandler>();
        services.AddScoped<AuthorizationHandler<UserIdRequirement>, UserIdRequirementHandler>();
        services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
        services.AddScoped<ILocalizationInfoProvider, HeaderLocalizationInfoProvider>();

        return services;
    }
}
