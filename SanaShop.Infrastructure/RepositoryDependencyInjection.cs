using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Infrastructure
{
    public static class RepositoryDependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            // Register your repositories here
            Assembly assembly = Assembly.GetExecutingAssembly();
            assembly.GetTypes()
                .Where(t => $"{assembly.GetName().Name}.Repository" == t.Namespace 
                && !t.IsAbstract
                && !t.IsInterface
                && t.IsInterface
                && t.Name.EndsWith("Repository"))
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
