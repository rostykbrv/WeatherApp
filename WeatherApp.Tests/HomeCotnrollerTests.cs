using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Controllers;
using WeatherApp.Data;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Tests
{
    public class HomeCotnrollerTests
    {
        [Fact]
        public async Task WeatherData_ReturnsViewResult_WithWeatherData()
        {
            // Arrange
            var weatherServiceMock = new Mock<IWeatherService>();
            weatherServiceMock
            .Setup(service => service.GetWeatherDataAsync(It.IsAny<string>()))
            .ReturnsAsync(new WeatherData
            {
                Humidity = 12.4F,
                Temperature = 16.2F,
                TimeRecorded = DateTime.UtcNow
            });

            var dbContextMock = new Mock<IWeatherAppDbContext>();

            HomeController controller = new HomeController(dbContextMock.Object, weatherServiceMock.Object);
            string query = "Los Angeles";

            // Act
            IActionResult result = await controller.WeatherData(query);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.Model);
        }
    }
}
