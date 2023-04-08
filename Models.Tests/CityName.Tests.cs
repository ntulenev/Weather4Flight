using FluentAssertions;

namespace Models.Tests;

public class CityNameTests
{
    [Theory(DisplayName = "CityName constructor should throw ArgumentException when city name is empty or whitespace")]
    [Trait("Category", "Unit")]
    [InlineData("")]
    [InlineData("  ")]
    public void CityName_Constructor_ShouldThrowArgumentException_WhenCityNameIsEmptyOrWhitespace(string invalidValue)
    {
        // Act & Assert
        var exception = Record.Exception(() => new CityName(invalidValue));

        // Assert
        exception.Should().BeOfType<ArgumentException>();
    }

    [Fact(DisplayName = "CityName constructor should throw ArgumentException when city name is null")]
    [Trait("Category", "Unit")]
    public void CityName_Constructor_ShouldThrowArgumentException_WhenCityNameIsNull()
    {
        // Act & Assert
        var exception = Record.Exception(() => new CityName(null!));

        // Assert
        exception.Should().BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "CityName constructor should set Value property when city name is not null or empty")]
    [Trait("Category", "Unit")]
    public void CityName_Constructor_ShouldSetValue_WhenCityNameIsNotNullOrEmpty()
    {
        // Arrange
        string cityName = "New York";

        // Act
        var city = new CityName(cityName);

        // Assert
        city.Value.Should().Be(cityName);
    }
}
