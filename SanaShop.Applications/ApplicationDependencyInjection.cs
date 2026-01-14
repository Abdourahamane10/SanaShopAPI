using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SanaShop.Applications.Common.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register your dependency injection here

            Assembly assembly = Assembly.GetExecutingAssembly();

            //MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            //AutoMapper
            services.AddAutoMapper(assembly);

            //PipelineBehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            //Validators
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}
