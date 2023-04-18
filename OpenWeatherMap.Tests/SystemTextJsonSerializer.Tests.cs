using OpenWeatherMap.Serialization;

using FluentAssertions;

using OpenWeatherMap.DTO;

namespace OpenWeatherMap.Tests;

public class SystemTextJsonSerializerTests
{
    [Fact(DisplayName = "Deserialize should throw ArgumentNullException when json is null")]
    [Trait("Category", "Unit")]
    public void Deserialize_Should_Throw_ArgumentNullException_When_Json_Is_Null()
    {
        // Arrange
        var serializer = new SystemTextJsonSerializer();
        string json = null!;

        // Act
        var action = new Action(() => serializer.Deserialize<string>(json));

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "Deserialize should throw ArgumentException when json is empty")]
    [Trait("Category", "Unit")]
    public void Deserialize_Should_Throw_ArgumentException_When_Json_Is_Empty()
    {
        // Arrange
        var serializer = new SystemTextJsonSerializer();
        var json = "";

        // Act
        var action = new Action(() => serializer.Deserialize<string>(json));

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact(DisplayName = "Deserialize should throw ArgumentException when json is whitespace")]
    [Trait("Category", "Unit")]
    public void Deserialize_Should_Throw_ArgumentException_When_Json_Is_Whitespace()
    {
        // Arrange
        var serializer = new SystemTextJsonSerializer();
        var json = "   ";

        // Act
        var action = new Action(() => serializer.Deserialize<string>(json));

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact(DisplayName = "Deserialize should deserialize json string to object of type T")]
    [Trait("Category", "Unit")]
    public void Deserialize_Should_Deserialize_Json_String_To_Object_Of_Type_T()
    {
        // Arrange
        var serializer = new SystemTextJsonSerializer();
        var json = "{\"name\":\"New York\"}";

        // Act
        var city = serializer.Deserialize<City>(json);

        // Assert
        city.Should().NotBeNull();
        city.Name.Should().Be("New York");
    }
}
