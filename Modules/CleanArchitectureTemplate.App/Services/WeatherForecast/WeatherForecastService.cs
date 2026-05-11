using CleanArchitectureTemplate.App.Interfaces.WeatherForecast;
using CleanArchitectureTemplate.App.Services.WeatherForecast.Models;

namespace CleanArchitectureTemplate.App.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            this.weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<IEnumerable<WeatherForecastResponse>> GetAllAsync()
        {
            var data = await weatherForecastRepository.GetAllAsync();

            return data.Select(x => new WeatherForecastResponse
            {
                Id = x.Id,
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary
            });
        }

        public async Task<WeatherForecastResponse> GetByIdAsync(Guid id)
        {
            var data = await weatherForecastRepository.GetByIdAsync(id);

            if (data is null)
            {
                return new WeatherForecastResponse();
            }

            return new WeatherForecastResponse
            {
                Id = data.Id,
                Date = data.Date,
                TemperatureC = data.TemperatureC,
                Summary = data.Summary
            };
        }
    }
}