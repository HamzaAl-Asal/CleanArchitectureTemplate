using CleanArchitectureTemplate.Domain.Entities.WeatherForecast;

namespace CleanArchitectureTemplate.App.Interfaces.WeatherForecast
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<WeatherForecastEntity>> GetAllAsync();
        Task<WeatherForecastEntity> GetByIdAsync(Guid id);
    }
}