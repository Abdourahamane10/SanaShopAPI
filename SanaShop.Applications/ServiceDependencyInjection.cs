using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications
{
    public static class ServiceDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Register your services here
            Assembly assembly = Assembly.GetExecutingAssembly();
            assembly.GetTypes()
                .Where(t => $"{assembly.GetName().Name}.Service" == t.Namespace 
                && !t.IsAbstract
                && !t.IsInterface
                && t.Name.EndsWith("Service"))
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(serviceType =>
                    {
                        services.AddScoped(serviceType, typesToRegister.assignedType);
                    });
                });
        }
    }
}
