using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators; 
public static class DependencyInjection 
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

        return services.AddScoped<ITranslator<LoginDtoValidationMessage>, LoginDtoMessageTranslator>()
                       .AddScoped<ITranslator<RegisterDtoValidationMessage>, RegisterDtoMessageTranslator>()
                       .AddScoped<ITranslator<CreateAdvertisementDtoValidationMessage>, CreateAdvertisementDtoMessageTranslator>();
    }
}
