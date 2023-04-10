using OpenWeatherMap.DTO;

using System.Text.Json;

using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class WeatherTests
{
    [Fact(DisplayName = "Deserialize should return a Weather object when given valid JSON")]
    public void Deserialize_Should_Return_Weather_Object_When_Given_Valid_JSON()
    {
        // Arrange
        var json = "{\"main\": \"Clouds\"}";

        // Act
        var weather = JsonSerializer.Deserialize<Weather>(json);

        // Assert
        weather.Should().NotBeNull();
        weather!.Main.Should().Be("Clouds");
    }
}
