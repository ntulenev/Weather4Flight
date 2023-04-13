using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using OpenWeatherMap.Logic;

namespace Logic.Tests;

public class WeatherForecastServiceTests
{
    [Fact(DisplayName = "Constructor should throw ArgumentNullException when openWeatherLoader is null")]
    public void Constructor_ShouldThrowArgumentNullException_WhenOpenWeatherLoaderIsNull()
    {
        // Arrange
        IOpenWeatherLoader openWeatherLoader = null!;
        IForecastConverter forecastConverter = Mock.Of<IForecastConverter>(MockBehavior.Strict);
        ILogger<WeatherForecastService> logger = Mock.Of<ILogger<WeatherForecastService>>(MockBehavior.Strict);

        // Act 
        Action action = () => _ = new WeatherForecastService(openWeatherLoader, forecastConverter, logger);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "Constructor should throw ArgumentNullException when forecastConverter is null")]
    public void Constructor_ShouldThrowArgumentNullException_WhenForecastConverterIsNull()
    {
        // Arrange
        IOpenWeatherLoader openWeatherLoader = Mock.Of<IOpenWeatherLoader>(MockBehavior.Strict);
        IForecastConverter forecastConverter = null!;
        ILogger<WeatherForecastService> logger = Mock.Of<ILogger<WeatherForecastService>>(MockBehavior.Strict);

        // Act
        Action action = () => _ = new WeatherForecastService(openWeatherLoader, forecastConverter, logger);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "Constructor should throw ArgumentNullException when logger is null")]
    public void Constructor_ShouldThrowArgumentNullException_WhenLoggerIsNull()
    {
        // Arrange
        IOpenWeatherLoader openWeatherLoader = Mock.Of<IOpenWeatherLoader>(MockBehavior.Strict);
        IForecastConverter forecastConverter = Mock.Of<IForecastConverter>(MockBehavior.Strict);
        ILogger<WeatherForecastService> logger = null!;

        // Act
        Action action = () => _ = new WeatherForecastService(openWeatherLoader, forecastConverter, logger);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "WeatherForecastService object should be created with valid parameters")]
    public void WeatherForecastService_ShouldBeCreated_WithValidParameters()
    {
        // Arrange
        IOpenWeatherLoader openWeatherLoader = Mock.Of<IOpenWeatherLoader>();
        IForecastConverter forecastConverter = Mock.Of<IForecastConverter>();
        ILogger<WeatherForecastService> logger = Mock.Of<ILogger<WeatherForecastService>>();

        // Act
        Action action = () => _ = new WeatherForecastService(openWeatherLoader, forecastConverter, logger);

        // Assert
        action.Should().NotThrow();
    }
}
