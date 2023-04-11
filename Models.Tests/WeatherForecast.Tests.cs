using FluentAssertions;

namespace Models.Tests;

public class WeatherForecastTests
{
    [Fact(DisplayName = "WeatherForecast constructor should throw ArgumentNullException when city name is null")]
    [Trait("Category", "Unit")]
    public void WeatherForecast_Constructor_ShouldThrowArgumentNullException_WhenCityNameIsNull()
    {
        // Act & Assert
        var exception = Record.Exception(() => new WeatherForecast(null!, new Dictionary<DateTimeOffset, Weather>()));

        // Assert
        exception.Should().BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "WeatherForecast constructor should throw ArgumentNullException when weather conditions are null")]
    [Trait("Category", "Unit")]
    public void WeatherForecast_Constructor_ShouldThrowArgumentNullException_WhenWeatherConditionsAreNull()
    {
        // Act & Assert
        var exception = Record.Exception(() => new WeatherForecast(new CityName("New York"), null!));

        // Assert
        exception.Should().BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "WeatherForecast should correctly return the city name")]
    [Trait("Category", "Unit")]
    public void WeatherForecast_ShouldReturnCorrectCityName()
    {
        // Arrange
        var cityName = new CityName("New York");
        var weatherConditions = new Dictionary<DateTimeOffset, Weather>();

        // Act
        var forecast = new WeatherForecast(cityName, weatherConditions);

        // Assert
        forecast.CityName.Should().Be(cityName);
    }

    [Fact(DisplayName = "WeatherForecast should correctly return the weather conditions")]
    [Trait("Category", "Unit")]
    public void WeatherForecast_ShouldReturnCorrectWeatherConditions()
    {
        // Arrange
        var cityName = new CityName("New York");
        var weatherConditions = new Dictionary<DateTimeOffset, Weather>
        {
            { DateTimeOffset.Now, new Weather(new Temperature(20), new WindSpeed(10), PrecipitationType.Rain) },
            { DateTimeOffset.Now.AddHours(1), new Weather(new Temperature(22), new WindSpeed(12), PrecipitationType.None) }
        };

        // Act
        var forecast = new WeatherForecast(cityName, weatherConditions);

        // Assert
        forecast.WeatherConditions.Should().BeEquivalentTo(weatherConditions);
    }
}
