using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
using CleanArchitectureTemplate.App.Services.WeatherForecast.Models;
using CleanArchitectureTemplate.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.Endpoints.WeatherForecast
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapWeatherForecastEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/weatherforecast")
                .WithTags("Weather Forecast");

            group.MapGet("/", HandleGetAll);
            group.MapGet("/{id:guid}", HandleGetById);

            return app;
        }

        private static async Task<IResult> HandleGetAll([FromServices] IWeatherForecastService weatherForecastService)
        {
            var response = await weatherForecastService.GetAllAsync();

            return Results.Ok(new ApiResponse<IEnumerable<WeatherForecastResponse>>
            {
                Success = true,
                Data = response
            });
        }

        private static async Task<IResult> HandleGetById(
            [FromRoute] Guid id,
            [FromServices] IWeatherForecastService weatherForecastService)
        {
            var response = await weatherForecastService.GetByIdAsync(id);

            if (response is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(new ApiResponse<WeatherForecastResponse>
            {
                Success = true,
                Data = response
            });
        }
    }
}
