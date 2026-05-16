using CleanArchitectureTemplate.App.Services.WeatherForecast.Models;
using CleanArchitectureTemplate.Domain.Entities.WeatherForecast;

namespace CleanArchitectureTemplate.App.Mappers.WeatherForecast;

public static class WeatherForecastMapper
{
    public static WeatherForecastResponse MapToResponse(
        WeatherForecastEntity weatherForecast)
    {
        return new WeatherForecastResponse
        {
            Id = weatherForecast.Id,
            Date = weatherForecast.Date,
            TemperatureC = weatherForecast.TemperatureC,
            Summary = weatherForecast.Summary
        };
    }
}