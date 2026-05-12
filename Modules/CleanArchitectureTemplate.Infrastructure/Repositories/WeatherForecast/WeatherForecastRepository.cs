using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
using CleanArchitectureTemplate.Domain.Entities.WeatherForecast;

namespace CleanArchitectureTemplate.Infrastructure.Repositories.WeatherForecast
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private static readonly IReadOnlyList<string> Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private static readonly List<WeatherForecastEntity> WeatherForecasts =
        [
            .. Enumerable.Range(1, 5)
            .Select(index => new WeatherForecastEntity
            {
                Id = Guid.NewGuid(),
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Count)]
            })
        ];

        public Task<IEnumerable<WeatherForecastEntity>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<WeatherForecastEntity>>(WeatherForecasts);
        }

        public Task<WeatherForecastEntity?> GetByIdAsync(Guid id)
        {
            var weatherForecast = WeatherForecasts.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(weatherForecast);
        }
    }
}