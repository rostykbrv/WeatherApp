using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Data
{
    public class WeatherAppDbContext:DbContext, IWeatherAppDbContext
    {
        public WeatherAppDbContext(DbContextOptions<WeatherAppDbContext> options):base(options)
        {
            
        }

        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<CityLocation> CityLocation { get; set; }
    }
}
