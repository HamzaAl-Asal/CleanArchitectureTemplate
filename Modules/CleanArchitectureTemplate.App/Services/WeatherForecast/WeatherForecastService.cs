using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
using CleanArchitectureTemplate.App.Mappers.WeatherForecast;
using CleanArchitectureTemplate.App.Services.WeatherForecast.Models;

namespace CleanArchitectureTemplate.App.Services.WeatherForecast;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherForecastRepository weatherForecastRepository;

    public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
    {
        this.weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<IEnumerable<WeatherForecastResponse>> GetAllAsync()
    {
        var weatherForecasts = await weatherForecastRepository.GetAllAsync();

        var mappedWeatherForecasts = weatherForecasts
            .Select(WeatherForecastMapper.MapToResponse)
            .ToList();

        return mappedWeatherForecasts;
    }

    public async Task<WeatherForecastResponse?> GetByIdAsync(Guid id)
    {
        var weatherForecast = await weatherForecastRepository.GetByIdAsync(id);

        if (weatherForecast is null)
        {
            return null;
        }

        var mappedWeatherForecast = WeatherForecastMapper.MapToResponse(weatherForecast);
        return mappedWeatherForecast;
    }
}