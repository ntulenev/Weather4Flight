using FluentAssertions;

namespace Models.Tests;

public class WeatherTests
{
    [Fact(DisplayName = "CreateFlightDecision with no reasons")]
    [Trait("Category", "Unit")]
    public void CreateFlightDecision_WithNoReasons_ReturnsGoodForFlight()
    {
        // Arrange
        var temperature = new Temperature(20m);
        var windSpeed = new WindSpeed(10m);
        var precipitations = PrecipitationType.None;
        var weather = new Weather(temperature, windSpeed, precipitations);

        // Act
        var decision = weather.CreateFlightDecision();

        // Assert
        decision.Recommendation.Should().Be(FlightRecommendation.GoodForFlight);
        decision.Reasons.Should().Be(NoFlightReasons.None);
    }

    [Fact(DisplayName = "CreateFlightDecision with reasons")]
    [Trait("Category", "Unit")]
    public void CreateFlightDecision_WithReasons_ReturnsBadForFlight()
    {
        // Arrange
        var temperature = new Temperature(-10m);
        var windSpeed = new WindSpeed(30m);
        var precipitations = PrecipitationType.Thunderstorm;
        var weather = new Weather(temperature, windSpeed, precipitations);

        // Act
        var decision = weather.CreateFlightDecision();

        // Assert
        decision.Recommendation.Should().Be(FlightRecommendation.BadForFlight);
        decision.Reasons.Should().Be(
            NoFlightReasons.ColdTemperature | NoFlightReasons.Wind | NoFlightReasons.ImportantPrecipitations);
    }

    [Fact(DisplayName = "CreateWeather with null temperature")]
    [Trait("Category", "Unit")]
    public void CreateWeather_WithNullTemperature_ThrowsArgumentNullException()
    {
        // Arrange
        var windSpeed = new WindSpeed(10m);
        var precipitations = PrecipitationType.None;

        // Act
        var exception = Record.Exception(() => new Weather(null!, windSpeed, precipitations));

        // Assert
        exception.Should().BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "CreateWeather with null wind speed")]
    [Trait("Category", "Unit")]
    public void CreateWeather_WithNullWindSpeed_ThrowsArgumentNullException()
    {
        // Arrange
        var temperature = new Temperature(20m);
        var precipitations = PrecipitationType.None;

        // Act
        var exception = Record.Exception(() => new Weather(temperature, null!, precipitations));

        // Assert
        exception.Should().BeOfType<ArgumentNullException>();
    }
}