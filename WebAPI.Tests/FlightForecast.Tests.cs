using System.Text.Json;
using System.Text.Json.Serialization;

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
        // Arrange
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
        items[0].Recommendation.Should().Be(FlightRecommendation.BadForFlight);
        items[0].Date.Should().Be(original[0].Key);
        items[0].WindSpeed.Should().Be(original[0].Value.WindSpeed.Value);
        items[0].Temperature.Should().Be(original[0].Value.Temperature.Value);
        items[0].Precipitations.Should().Be(original[0].Value.Precipitations);
        items[0].Reasons.Should().Be(NoFlightReasons.ImportantPrecipitations);
        items[1].Recommendation.Should().Be(FlightRecommendation.GoodForFlight);
        items[1].Date.Should().Be(original[1].Key);
        items[1].WindSpeed.Should().Be(original[1].Value.WindSpeed.Value);
        items[1].Temperature.Should().Be(original[1].Value.Temperature.Value);
        items[1].Precipitations.Should().Be(original[1].Value.Precipitations);
        items[1].Reasons.Should().Be(NoFlightReasons.None);

    }

    [Fact(DisplayName = "Can serialize WeatherForecast to JSON")]
    [Trait("Category", "Unit")]
    public void CanSerializeToJson()
    {
        // Arrange
        var cityName = new CityName("New York");
        var weatherConditions = new Dictionary<DateTimeOffset, Weather>
        {
            { new DateTimeOffset(2023, 4, 19, 10, 0, 0, TimeSpan.Zero), 
              new Weather(
                  new Temperature(20), 
                  new WindSpeed(10), 
                  PrecipitationType.Rain) 
            },
            { new DateTimeOffset(2023, 4, 20, 10, 0, 0, TimeSpan.Zero), 
                new Weather(
                    new Temperature(22), 
                    new WindSpeed(12), 
                    PrecipitationType.None) 
            }
        };

        var weatherForecast = new WeatherForecast(cityName, weatherConditions);
        var flightForecast = FlightForecast.CreateFromModel(weatherForecast);

        var expectedJson = "{\"data\":[{\"date\":\"2023-04-19T10:00:00+00:00\",\"recommendation\":\"BadForFlight\",\"reasons\":\"ImportantPrecipitations\",\"precipitations\":\"Rain\",\"temperature\":20,\"windSpeed\":10},{\"date\":\"2023-04-20T10:00:00+00:00\",\"recommendation\":\"GoodForFlight\",\"reasons\":\"None\",\"precipitations\":\"None\",\"temperature\":22,\"windSpeed\":12}]}";
        
        // Act
        var json = JsonSerializer.Serialize(flightForecast, new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        });

        // Assert
        json.Should().Be(expectedJson);
    }
}
