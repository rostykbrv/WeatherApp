using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherAppDbContext
    {
        DbSet<WeatherData> WeatherData { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
