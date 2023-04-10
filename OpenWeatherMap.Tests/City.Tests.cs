using OpenWeatherMap.DTO;

using System.Text.Json;
using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class CityTests
{
    [Fact(DisplayName = "Valid JSON string should be deserialized into a City object")]
    public void Valid_Json_String_Should_Be_Deserialized_Into_A_City_Object()
    {
        // Arrange
        var json = "{\"name\":\"New York\"}";

        // Act
        var actualCity = JsonSerializer.Deserialize<City>(json);

        // Assert
        actualCity.Should().NotBeNull();
        actualCity!.Name.Should().Be("New York");
    }
}
