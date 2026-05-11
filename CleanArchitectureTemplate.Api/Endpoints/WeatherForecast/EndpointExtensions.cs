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
            var group = app.MapGroup("api/weatherforecast");

            group.MapGet("/", HandleGetAll);
            group.MapGet("/{id:guid}", HandleGetById);

            return app;
        }

        private static async Task<IResult> HandleGetAll([FromServices] IWeatherForecastService weatherForecastservice)
        {
            var response = await weatherForecastservice.GetAllAsync();

            return Results.Ok(new ApiResponse<IEnumerable<WeatherForecastResponse>>
            {
                Success = true,
                Data = response
            });
        }

        private static async Task<IResult> HandleGetById(
            [FromRoute] Guid id,
            [FromServices] IWeatherForecastService weatherForecastservice)
        {
            var response = await weatherForecastservice.GetByIdAsync(id);

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