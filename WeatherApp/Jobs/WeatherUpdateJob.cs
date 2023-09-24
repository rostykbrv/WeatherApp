using Hangfire;
using WeatherApp.Data;
using WeatherApp.Services;

namespace WeatherApp.Jobs
{
    public class WeatherUpdateJob
    {
        private readonly IWeatherAppDbContext _dbContext;
        private readonly IWeatherService _weatherService;

        public WeatherUpdateJob(IWeatherAppDbContext dbContext, IWeatherService weatherService)
        {
            _dbContext = dbContext;
            _weatherService = weatherService;
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task UpdateWeatherData(string query)
        {
            await _weatherService.GetWeatherDataAsync(query);
        }
    }
}
