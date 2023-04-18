using OpenWeatherMap.DTO;
using System.Text.Json;
using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class WeatherForecastTests
{
    [Fact(DisplayName = "Deserialize should return a WeatherForecast object when given valid JSON")]
    [Trait("Category", "Unit")]
    public void Deserialize_Should_Return_WeatherForecast_Object_When_Given_Valid_JSON()
    {
        // Arrange
        var json = "{\"city\": {\"name\": \"London\"}, \"list\": [{\"dt_txt\": \"2023-04-11 12:00:00\", \"wind\": {\"speed\": 3.2}, \"main\": {\"temp\": 20.5}, \"weather\": [{\"main\": \"Clouds\"}]}]}";

        // Act
        var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json);

        // Assert
        weatherForecast.Should().NotBeNull();
        weatherForecast!.City.Should().NotBeNull();
        weatherForecast.City.Name.Should().Be("London");
        weatherForecast.WeatherDataList.Should().NotBeNull();
        weatherForecast.WeatherDataList.Should().HaveCount(1);
        weatherForecast.WeatherDataList[0].Should().NotBeNull();
        weatherForecast.WeatherDataList[0].DateText.Should().Be("2023-04-11 12:00:00");
        weatherForecast.WeatherDataList[0].Wind.Should().NotBeNull();
        weatherForecast.WeatherDataList[0].Wind.Speed.Should().Be(3.2);
        weatherForecast.WeatherDataList[0].Main.Should().NotBeNull();
        weatherForecast.WeatherDataList[0].Main.Temp.Should().Be(20.5);
        weatherForecast.WeatherDataList[0].Weather.Should().NotBeNull();
        weatherForecast.WeatherDataList[0].Weather.Should().HaveCount(1);
        weatherForecast.WeatherDataList[0].Weather[0].Should().NotBeNull();
        weatherForecast.WeatherDataList[0].Weather[0].Main.Should().Be("Clouds");
    }
}
