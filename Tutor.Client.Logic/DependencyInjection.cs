using Microsoft.Extensions.DependencyInjection;
using Tutor.Client.Logic.Helpers;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Client.Logic;

public static class DependencyInjection
{
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        return services.AddScoped<IEmailValidationHelper, ClientEmailValidationHelper>();
    }
}
