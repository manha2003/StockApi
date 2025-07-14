using ApplicationLayer;
using ApplicationLayer.Interfaces.Repositories;
using ApplicationLayer.Services;
using InfrastructureLayer;
using InfrastructureLayer.Data;
using InfrastructureLayer.Helpers;
using InfrastructureLayer.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
