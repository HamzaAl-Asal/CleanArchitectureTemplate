using CleanArchitectureTemplate.Api.Endpoints.WeatherForecast;
using CleanArchitectureTemplate.App;
using CleanArchitectureTemplate.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services
    .RegisterAppModuleServices()
    .RegisterInfrastructureModuleServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapWeatherForecastEndpoints();

app.Run();