using OpenWeatherMap.DTO;

using System.Text.Json;

using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class WeatherDataTests
{
    [Fact(DisplayName = "Deserialize should return a WeatherData object when given valid JSON")]
    [Trait("Category", "Unit")]
    public void Deserialize_Should_Return_WeatherData_Object_When_Given_Valid_JSON()
    {
        // Arrange
        var json = 
            "{\"dt_txt\": \"2023-04-11 12:00:00\", " +
            "\"wind\": {\"speed\": 3.2}, \"main\": {\"temp\": 20.5}, \"weather\": [{\"main\": \"Clouds\"}]}";

        // Act
        var weatherData = JsonSerializer.Deserialize<WeatherData>(json);

        // Assert
        weatherData.Should().NotBeNull();
        weatherData!.DateText.Should().Be("2023-04-11 12:00:00");
        weatherData.Wind.Should().NotBeNull();
        weatherData.Wind.Speed.Should().Be(3.2);
        weatherData.Main.Should().NotBeNull();
        weatherData.Main.Temp.Should().Be(20.5);
        weatherData.Weather.Should().NotBeNull();
        weatherData.Weather.Should().HaveCount(1);
        weatherData.Weather[0].Should().NotBeNull();
        weatherData.Weather[0].Main.Should().Be("Clouds");
    }
}
