using OpenWeatherMap.DTO;
using System.Text.Json;
using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class WindDataTests
{
    [Fact(DisplayName = "Deserialize should return a WindData object when given valid JSON")]
    public void Deserialize_Should_Return_WindData_Object_When_Given_Valid_JSON()
    {
        // Arrange
        var json = "{\"speed\": 3.2}";

        // Act
        var windData = JsonSerializer.Deserialize<WindData>(json);

        // Assert
        windData.Should().NotBeNull();
        windData!.Speed.Should().Be(3.2);
    }
}
