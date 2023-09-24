using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WeatherApp.Data;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherAppDbContext _weatherAppDbContext;
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherAppDbContext weatherAppDbContext, IWeatherService weatherService)
        {
            _weatherAppDbContext = weatherAppDbContext;
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> WeatherData(string query)
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(query);
            return View(weatherData);
        }
    }
}