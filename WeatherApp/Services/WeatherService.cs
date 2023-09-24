using RestSharp;
using Newtonsoft.Json;
using WeatherApp.Data;
using WeatherApp.Models;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherAppDbContext _context;
        private readonly string _apiKey;

        public WeatherService(IWeatherAppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _apiKey = configuration.GetValue<string>("OpenWeatherMap:ApiKey");
        }

        public async Task<WeatherData> GetWeatherDataAsync(string query)
        {
            var client = new RestClient("http://api.openweathermap.org/");
            var request = new RestRequest("data/2.5/weather",Method.Get);
            request.AddParameter("appid", _apiKey);
            request.AddParameter("units", "metric");
            request.AddParameter("q", query);
            var responce = await client.ExecuteAsync(request);

            // Deserialize the response
            var apiResponse = JsonConvert.DeserializeObject<JObject>(responce.Content);
            var weatherData = new WeatherData
            {
                Temperature = apiResponse["main"]["temp"].Value<float>(),
                Humidity = apiResponse["main"]["humidity"].Value<float>(),
                TimeRecorded = DateTime.UtcNow
            };

            _context.WeatherData.Add(weatherData);
            await _context.SaveChangesAsync();

            return weatherData;
        }

    }
}
