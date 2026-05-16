using CleanArchitectureTemplate.App.Services.WeatherForecast.Models;

namespace CleanArchitectureTemplate.App.Interfaces.WeatherForecast
{

    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastResponse>> GetAllAsync();
        Task<WeatherForecastResponse?> GetByIdAsync(Guid id);
    }
}