using CleanArchitectureTemplate.App.Services.WeatherForecast.Models;
using CleanArchitectureTemplate.Domain.Entities.WeatherForecast;

namespace CleanArchitectureTemplate.App.Interfaces.WeatherForecast
{

    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastResponse>> GetAllAsync();
        Task<WeatherForecastResponse> GetByIdAsync(Guid id);
    }
}