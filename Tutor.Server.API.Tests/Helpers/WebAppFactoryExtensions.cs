using Microsoft.AspNetCore.Authorization.Policy;
using System.Security.Claims;
using Tutor.Server.Domain.Entities;
using WebAppFac = Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program>;

namespace Tutor.Server.API.Tests.Helpers;

public static class WebAppFactoryExtensions
{
    public static WebAppFac WithService<TService>(this WebAppFac factory, TService service, Type serviceType)
            where TService : class
    {
        if (service is null)
        {
            throw new ArgumentNullException("service");
        }

        if (serviceType is null)
        {
            throw new ArgumentNullException("serviceType");
        }

        return factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var currentlyRegistered = services.SingleOrDefault(s => s.ServiceType == serviceType);

                if (currentlyRegistered != null)
                {
                    services.Remove(currentlyRegistered);
                }

                services.AddSingleton(serviceType, service);
            });
        });
    }

    public static WebAppFac WithService<TService>(this WebAppFac factory, TService service)
            where TService : class
    {
        return WithService(factory, service, typeof(TService));
    }

    public static WebAppFac WithClaimsPrincipal(this WebAppFac factory, User user)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var policyEvaluator = new FakePolicyEvaluator();
        policyEvaluator.ClaimsIdentity = new ClaimsIdentity(claims);
        return factory.WithService(policyEvaluator, typeof(IPolicyEvaluator));
    }
}
