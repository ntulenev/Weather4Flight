using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;

using Models;
using WebAPI.DTO;

namespace WebAPI.Tests;

public class WeatherFlightDataTests
{
    [Fact(DisplayName = "Can serialize WeatherFlightData to JSON")]
    [Trait("Category", "Unit")]
    public void CanSerializeToJson()
    {
        // Arrange
        var weatherFlightData = new WeatherFlightData
        {
            Date = new DateTimeOffset(2023, 4, 19, 10, 0, 0, TimeSpan.Zero),
            Recomendation = FlightRecomendation.GoodForFlight,
            Reasons = NoFlightReasons.None,
            Precipitations = PrecipitationType.Rain,
            Temperature = 15.5m,
            WindSpeed = 25.0m
        };

        var expectedJson = "{\"date\":\"2023-04-19T10:00:00+00:00\",\"recomendation\":\"GoodForFlight\",\"reasons\":\"None\",\"precipitations\":\"Rain\",\"temperature\":15.5,\"windSpeed\":25.0}";

        // Act
        var json = JsonSerializer.Serialize(weatherFlightData, new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        });

        // Assert
        json.Should().Be(expectedJson);
    }
}