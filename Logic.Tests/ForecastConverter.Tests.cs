using FluentAssertions;

using Models;
using DTO = OpenWeatherMap.DTO;

namespace Logic.Tests;
public class ForecastConverterTests
{
    [Fact(DisplayName = "ForecastConverter should be creatable")]
    public void ForecastConverter_ShouldBeCreatable()
    {
        // Act
        Action action = () => _ = new ForecastConverter();

        // Assert
        action.Should().NotThrow();
    }

    [Fact(DisplayName = "Convert should throw ArgumentNullException when weatherForecast is null")]
    public void Convert_ShouldThrowArgumentNullException_WhenWeatherForecastIsNull()
    {
        // Arrange
        var converter = new ForecastConverter();

        // Arrange & Act
        Action action = () => _ = converter.Convert(null!);

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "Convert should return expected WeatherForecast when weatherForecast is not null")]
    public void Convert_ShouldReturnExpectedWeatherForecast_WhenWeatherForecastIsNotNull()
    {
        // Arrange
        var converter = new ForecastConverter();

        var weatherDataList = new List<DTO.WeatherData>
        {
            new DTO.WeatherData
            {
                DateText = "2023-04-13 12:00:00",
                Main = new DTO.MainData {  Temp = 20 },
                Wind = new DTO.WindData { Speed = 10.0 },
                Weather = new List<DTO.Weather>
                {
                    new DTO.Weather
                    {
                         Main = "sleet"
                    },
                    new DTO.Weather
                    {
                        Main = "freezing rain"
                    },
                    new DTO.Weather
                    {
                        Main = "123123123"
                    }
                }
            },
            new DTO.WeatherData
            {
                DateText = "2023-04-14 12:00:00",
                Main = new DTO.MainData {  Temp = 21 },
                Wind = new DTO.WindData { Speed = 15.0 },
                Weather = new List<DTO.Weather>
                {
                    new DTO.Weather
                    {
                         Main = "none"
                    }
                }
            }
        };

        var weatherForecast = new DTO.WeatherForecast
        {
            City = new DTO.City { Name = "Seattle" },
            WeatherDataList = weatherDataList
        };

        var expectedWeatherForecast = new WeatherForecast(
            new CityName("Seattle"),
            new Dictionary<DateTimeOffset, Weather>
            {
                { new DateTimeOffset(2023, 4, 13, 12, 0, 0, TimeSpan.Zero), new Weather(new Temperature(20), new WindSpeed(10), PrecipitationType.Squalls | PrecipitationType.FreezingRain | PrecipitationType.Other) },
                { new DateTimeOffset(2023, 4, 14, 12, 0, 0, TimeSpan.Zero), new Weather(new Temperature(21), new WindSpeed(15), PrecipitationType.None) }
            }
        );

        // Act
        var result = converter.Convert(weatherForecast);

        // Assert
        result.Should().BeEquivalentTo(expectedWeatherForecast);
    }
}
