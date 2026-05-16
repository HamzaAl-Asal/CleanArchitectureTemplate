using CleanArchitectureTemplate.Api.Endpoints.WeatherForecast;

namespace CleanArchitectureTemplate.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication RegisterApiEndpoints(this WebApplication app)
    {
        app.MapWeatherForecastEndpoints();

        return app;
    }
}