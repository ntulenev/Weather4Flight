using FluentAssertions;

namespace Models.Tests;

public class TemperatureTests
{
    [Fact(DisplayName = "Given temperature value below absolute zero, " +
        "when creating temperature object, then should throw ArgumentException")]
    [Trait("Category", "Unit")]
    public void GivenTemperatureValueBelowAbsoluteZero_WhenCreatingTemperatureObject_ThenShouldThrowArgumentException()
    {
        // Arrange
        decimal value = -300M;

        // Act
        var exception = Record.Exception(() => new Temperature(value));

        // Assert
        exception.Should().BeOfType<ArgumentException>();
    }

    [Theory(DisplayName = "Given temperature value, when getting temperature category, " +
        "then should return correct category")]
    [Trait("Category", "Unit")]
    [InlineData(-50, TemperatureCategory.Cold)]
    [InlineData(0, TemperatureCategory.Normal)]
    [InlineData(10, TemperatureCategory.Normal)]
    [InlineData(35, TemperatureCategory.Normal)]
    [InlineData(40, TemperatureCategory.Hot)]
    public void GivenTemperatureValue_WhenGettingTemperatureCategory_ThenShouldReturnCorrectCategory(
        decimal value, 
        TemperatureCategory expectedCategory)
    {
        // Arrange
        var temperature = new Temperature(value);

        // Act
        var actualCategory = temperature.Category;

        // Assert
        actualCategory.Should().Be(expectedCategory);
    }
}
