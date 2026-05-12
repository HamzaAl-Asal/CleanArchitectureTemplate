using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
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

        var response = weatherForecasts.Select(x => new WeatherForecastResponse
        {
            Id = x.Id,
            Date = x.Date,
            TemperatureC = x.TemperatureC,
            Summary = x.Summary
        });

        return response;
    }

    public async Task<WeatherForecastResponse> GetByIdAsync(Guid id)
    {
        var weatherForecast = await weatherForecastRepository.GetByIdAsync(id);

        if (weatherForecast is null)
        {
            return new WeatherForecastResponse();
        }

        return new WeatherForecastResponse
        {
            Id = weatherForecast.Id,
            Date = weatherForecast.Date,
            TemperatureC = weatherForecast.TemperatureC,
            Summary = weatherForecast.Summary
        };
    }
}