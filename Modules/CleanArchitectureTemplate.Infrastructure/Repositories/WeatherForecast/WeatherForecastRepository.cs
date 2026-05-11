using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
using CleanArchitectureTemplate.Domain.Entities.WeatherForecast;

namespace CleanArchitectureTemplate.Infrastructure.Repositories.WeatherForecast
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<WeatherForecastEntity> WeatherForecasts =
            [.. Enumerable.Range(1, 5)
            .Select(index => new WeatherForecastEntity
            {
                Id = Guid.NewGuid(),
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })];

        public async Task<IEnumerable<WeatherForecastEntity>> GetAllAsync()
        {
            await Task.CompletedTask;

            return WeatherForecasts;
        }

        public async Task<WeatherForecastEntity> GetByIdAsync(Guid id)
        {
            await Task.CompletedTask;

            var data = WeatherForecasts.FirstOrDefault(x => x.Id == id);

            if (data is null)
            {
                return new WeatherForecastEntity();
            }

            return data;
        }
    }
}