using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();
         

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(configuration => configuration.AddMaps(assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
