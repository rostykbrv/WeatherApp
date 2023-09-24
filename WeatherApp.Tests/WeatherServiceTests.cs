using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using WeatherApp.Data;
using WeatherApp.Services;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public async Task GetWeatherDataAsync_ReturnsWeatherData()
        {
            // Arrange
            var weatherDataSetMock = new Mock<DbSet<WeatherData>>();

            var dbContextMock = new Mock<IWeatherAppDbContext>();
            dbContextMock.Setup(x => x.WeatherData).Returns(weatherDataSetMock.Object);

            var apiKey = "b4a8a33b87048bb89f733da7ee6448a3";
            var configurationSectionMock = new Mock<IConfigurationSection>();
            configurationSectionMock.SetupGet(x => x.Value).Returns(apiKey);

            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(x => x.GetSection("OpenWeatherMap:ApiKey")).Returns(configurationSectionMock.Object);

            WeatherService weatherService = new WeatherService(dbContextMock.Object, configurationMock.Object);
            string query = "Los Angeles";

            // Act
            var weatherData = await weatherService.GetWeatherDataAsync(query);

            // Assert
            Assert.NotNull(weatherData);
        }
    }
}
