using System.Text.Json;

using FluentAssertions;

using Models;
using WebAPI.DTO;

namespace WebAPI.Tests;

public class FlightForecastTests
{
    [Fact(DisplayName = "CreateFromModel throws ArgumentNullException when weatherForecast is null")]
    [Trait("Category", "Unit")]
    public void CreateFromModel_WithNullWeatherForecast_ThrowsArgumentNullException()
    {
        // Arrange
        WeatherForecast weatherForecast = null!;

        // Act
        Action act = () => FlightForecast.CreateFromModel(weatherForecast);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "CreateFromModel returns expected FlightForecast when weatherForecast is valid")]
    [Trait("Category", "Unit")]
    public void CreateFromModel_WithValidWeatherForecast_ReturnsExpectedFlightForecast()
    {
        var cityName = new CityName("New York");
        var weatherConditions = new Dictionary<DateTimeOffset, Weather>
        {
            { DateTimeOffset.Now, new Weather(new Temperature(20), new WindSpeed(10), PrecipitationType.Rain) },
            { DateTimeOffset.Now.AddHours(1), new Weather(new Temperature(22), new WindSpeed(12), PrecipitationType.None) }
        };

        var weatherForecast = new WeatherForecast(cityName, weatherConditions);

        // Act
        var flightForecast = FlightForecast.CreateFromModel(weatherForecast);

        // Assert
        flightForecast.Should().NotBeNull();
        flightForecast.Data.Should().NotBeNullOrEmpty();
        flightForecast.Data.Should().HaveCount(2);
        var items = flightForecast.Data.ToList();
        var original = weatherConditions.ToList();
        items[0].Recomendation.Should().Be(FlightRecomendation.BadForFlight);
        items[0].Date.Should().Be(original[0].Key);
        items[0].WindSpeed.Should().Be(original[0].Value.WindSpeed.Value);
        items[0].Temperature.Should().Be(original[0].Value.Temperature.Value);
        items[0].Precipitations.Should().Be(original[0].Value.Precipitations);
        items[0].Reasons.Should().Be(NoFlightReasons.ImportantPrecipitations);
        items[1].Recomendation.Should().Be(FlightRecomendation.GoodForFlight);
        items[1].Date.Should().Be(original[1].Key);
        items[1].WindSpeed.Should().Be(original[1].Value.WindSpeed.Value);
        items[1].Temperature.Should().Be(original[1].Value.Temperature.Value);
        items[1].Precipitations.Should().Be(original[1].Value.Precipitations);
        items[1].Reasons.Should().Be(NoFlightReasons.None);

    }
}
