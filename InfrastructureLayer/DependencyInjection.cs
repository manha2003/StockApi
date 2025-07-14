using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer (this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<StockAppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("StockAppConnectionString")));

                return services;
        }
    }
}
