using FluentAssertions;

namespace Models.Tests;

public class FlightDecisionTests
{
    [Fact(DisplayName = "When BadForFlight, reasons must be specified")]
    [Trait("Category", "Unit")]
    public void BadForFlight_ReasonsMustBeSpecified()
    {
        // Arrange
        FlightRecomendation recommendation = FlightRecomendation.BadForFlight;
        NoFlightReasons reasons = NoFlightReasons.None;

        // Act
        var exception = Record.Exception(() => new FlightDecision(recommendation, reasons));

        // Assert
        exception.Should().BeOfType<ArgumentException>();
    }

    [Fact(DisplayName = "When GoodForFlight model should be created")]
    [Trait("Category", "Unit")]
    public void GoodForFlight_ShouldBeCreated()
    {
        // Arrange
        FlightRecomendation recommendation = FlightRecomendation.GoodForFlight;
        NoFlightReasons reasons = NoFlightReasons.ImportantPrecipitations;

        // Act
        var result = new FlightDecision(recommendation, reasons);

        // Assert
        result.Recomendation.Should().Be(recommendation);
        result.Reasons.Should().Be(reasons);
    }
}
