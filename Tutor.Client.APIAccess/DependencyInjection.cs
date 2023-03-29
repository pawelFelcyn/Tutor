using Microsoft.Extensions.DependencyInjection;
using Tutor.Client.APIAccess.Abstractions;

namespace Tutor.Client.APIAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddAPIAccess(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        return services.AddScoped<ILoginClient, LoginClient>()
                       .AddScoped<IRegistrationClient, RegistrationClient>()
                       .AddScoped<ISubjectClient, SubjectClient>()
                       .AddScoped<IAdvertisementClient, AdvertisementClient>();
    }
}
