using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
using CleanArchitectureTemplate.App.Services.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppModuleServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }
    }
}