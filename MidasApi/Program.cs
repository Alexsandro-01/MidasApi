using MidasApi.Services;
using MidasApi.Interfaces;
using Midas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MidasApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<IBalanceService, BalanceService>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<DataBaseContext>();
builder.Services.AddDbContext<DataBaseContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
