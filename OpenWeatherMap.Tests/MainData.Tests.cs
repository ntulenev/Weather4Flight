using OpenWeatherMap.DTO;
using System.Text.Json;
using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class MainDataTests
{
    [Fact(DisplayName = "Deserialize should return a MainData object when given valid JSON")]
    [Trait("Category", "Unit")]
    public void Deserialize_Should_Return_MainData_Object_When_Given_Valid_JSON()
    {
        // Arrange
        var json = "{\"temp\": 20.5}";

        // Act
        var mainData = JsonSerializer.Deserialize<MainData>(json);

        // Assert
        mainData.Should().NotBeNull();
        mainData!.Temp.Should().Be(20.5);
    }
}
