using ApplicationLayer.Interfaces.Repositories;
using ApplicationLayer.Interfaces.Services;
using ApplicationLayer.Services;
using InfrastructureLayer.Helpers;
using InfrastructureLayer.Repositories.Implementations;
using InfrastructureLayer.Services;
using InfrastructureLayer.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IWatchlistRepository, WatchlistRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IEmailService, EmailService>();

            services.Configure<EmailSettings>(config.GetSection("EmailSettings"));


            return services;
        }
    }
}
