using ApplicationLayer.Interfaces.Repositories;
using InfrastructureLayer.Data;
using InfrastructureLayer.Helpers;
using InfrastructureLayer.Repositories.Implementations;

using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StockAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockAppConnectionString"));


});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
