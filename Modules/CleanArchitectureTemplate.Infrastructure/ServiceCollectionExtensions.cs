using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
using CleanArchitectureTemplate.Infrastructure.Repositories.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterInfrastructureModuleServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            return services;
        }
    }
}