using FluentAssertions;

namespace Models.Tests;

public class WindSpeedTests
{
    [Fact(DisplayName = "WindSpeed should initialize with positive value")]
    [Trait("Category", "Unit")]
    public void WindSpeed_ShouldInitialize_WithPositiveValue()
    {
        // Arrange
        decimal value = 10m;

        // Act
        var windSpeed = new WindSpeed(value);

        // Assert
        windSpeed.Value.Should().Be(value);
    }

    [Fact(DisplayName = "WindSpeed should throw ArgumentOutOfRangeException for negative value")]
    [Trait("Category", "Unit")]
    public void WindSpeed_ShouldThrow_ArgumentOutOfRangeException_ForNegativeValue()
    {
        // Arrange
        decimal value = -10m;

        // Act
        var exception = Record.Exception(() => new WindSpeed(value));

        // Assert
        exception.Should().BeOfType<ArgumentOutOfRangeException>();
    }

    [Fact(DisplayName = "IsStrongWind should return true for wind speed greater than or equal to StrongWindThreshold")]
    [Trait("Category", "Unit")]
    public void IsStrongWind_ShouldReturnTrue_ForWindSpeedGreaterThanOrEqualToStrongWindThreshold()
    {
        // Arrange
        decimal value = 30m;
        var windSpeed = new WindSpeed(value);

        // Act
        bool result = windSpeed.IsStrongWind;

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "IsStrongWind should return false for wind speed less than StrongWindThreshold")]
    [Trait("Category", "Unit")]
    public void IsStrongWind_ShouldReturnFalse_ForWindSpeedLessThanStrongWindThreshold()
    {
        // Arrange
        decimal value = 20m;
        var windSpeed = new WindSpeed(value);

        // Act
        bool result = windSpeed.IsStrongWind;

        // Assert
        result.Should().BeFalse();
    }
}
