using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Server.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly
                    .GetTypes()
                    .Where(t => typeof(IMap).IsAssignableFrom(t) && !t.IsInterface)
                    .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var method = type.GetMethod(nameof(IMap.ConfigureMap));
            method.Invoke(instance, new object[] { this });
        }
    }
}
