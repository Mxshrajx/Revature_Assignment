using Xunit;
using Moq;
using MyApp;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApp.Tests;

public class WeatherServiceTests
{
    [Fact]
    public void GetWeather_ReturnsExpectedResult()
    {
        var mockWeatherService = new Mock<IWeatherService>();

        mockWeatherService
            .Setup(x => x.GetTemperature("New York"))
            .Returns(new List<double> { 30, 32, 28, 31, 29 });

        var weatherService = mockWeatherService.Object;

        var result = weatherService.GetTemperature("New York");

        Assert.NotNull(result);
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void GetWeather_ThrowsException()
    {
        var mockWeatherService = new Mock<IWeatherService>();

        mockWeatherService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Throws(new Exception("City Not Found"));

        var weatherService = mockWeatherService.Object;

        var ex = Assert.Throws<Exception>(() =>
            weatherService.GetTemperature("Some dummy city"));

        Assert.Equal("City Not Found", ex.Message);
    }
}