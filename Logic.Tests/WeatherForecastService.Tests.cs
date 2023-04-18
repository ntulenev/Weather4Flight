using FluentAssertions;

using Microsoft.Extensions.Logging;

using Models;

using Moq;

using OpenWeatherMap.Logic;

namespace Logic.Tests;

public class WeatherForecastServiceTests
{
    [Fact(DisplayName = "Constructor should throw ArgumentNullException when openWeatherLoader is null")]
    [Trait("Category", "Unit")]
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
    [Trait("Category", "Unit")]
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
    [Trait("Category", "Unit")]
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
    [Trait("Category", "Unit")]
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

    [Fact(DisplayName = "LoadWeatherForecastAsync should throw ArgumentNullException when cityName is null")]
    [Trait("Category", "Unit")]
    public async Task LoadWeatherForecastAsync_ShouldThrowArgumentNullException_WhenCityNameIsNull()
    {
        // Arrange
        var openWeatherLoaderMock = new Mock<IOpenWeatherLoader>(MockBehavior.Strict);
        var forecastConverterMock = new Mock<IForecastConverter>(MockBehavior.Strict);
        var loggerMock = new Mock<ILogger<WeatherForecastService>>(MockBehavior.Strict);

        var service = new WeatherForecastService(openWeatherLoaderMock.Object, forecastConverterMock.Object, loggerMock.Object);

        var cancellationToken = CancellationToken.None;

        // Act
        Func<Task> action = async () => await service.LoadWeatherForecastAsync(null!, cancellationToken);

        // Assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact(DisplayName = "LoadWeatherForecastAsync should rethrow exception thrown by GetWeatherForecastAsync")]
    [Trait("Category", "Unit")]
    public async Task LoadWeatherForecastAsync_ShouldRethrowException_WhenGetWeatherForecastAsyncThrowsException()
    {
        // Arrange
        var cityName = new CityName("Test City");
        using var ctsSource = new CancellationTokenSource();
        var cancellationToken = ctsSource.Token;

        var openWeatherLoaderMock = new Mock<IOpenWeatherLoader>(MockBehavior.Strict);
        openWeatherLoaderMock.Setup(x => x.GetWeatherForecastAsync(cityName.Value, cancellationToken))
                             .ThrowsAsync(new Exception("Test Exception"));

        var forecastConverterMock = new Mock<IForecastConverter>(MockBehavior.Strict);

        var loggerMock = new Mock<ILogger<WeatherForecastService>>();

        var service = new WeatherForecastService(openWeatherLoaderMock.Object, forecastConverterMock.Object, loggerMock.Object);

        // Act
        Func<Task> action = async () => await service.LoadWeatherForecastAsync(cityName, cancellationToken);

        // Assert
        await action.Should().ThrowAsync<Exception>();
    }

    [Fact(DisplayName = "LoadWeatherForecastAsync should return valid weather forecast")]
    [Trait("Category", "Unit")]
    public async Task LoadWeatherForecastAsync_ShouldReturnValidWeatherForecast()
    {
        // Arrange
        var cityName = new CityName("Test City");
        using var ctsSource = new CancellationTokenSource();
        var cancellationToken = ctsSource.Token;

        var expectedWeatherForecast = new WeatherForecast(cityName, new Dictionary<DateTimeOffset, Weather>());

        var openWeatherLoaderMock = new Mock<IOpenWeatherLoader>(MockBehavior.Strict);
        var dtoTest = new OpenWeatherMap.DTO.WeatherForecast
        {
            City = new OpenWeatherMap.DTO.City { Name = cityName.Value },
            WeatherDataList = new List<OpenWeatherMap.DTO.WeatherData>
                                   {
                                       new OpenWeatherMap.DTO.WeatherData
                                       {
                                            DateText = "123",
                                             Main = new OpenWeatherMap.DTO.MainData
                                             {
                                                  Temp = 1
                                             },
                                             Weather = new List<OpenWeatherMap.DTO.Weather>
                                             {
                                                 new OpenWeatherMap.DTO.Weather
                                                 {
                                                      Main = "test"
                                                 }
                                             },
                                              Wind = new OpenWeatherMap.DTO.WindData
                                              {
                                                   Speed = 1
                                              }
                                       }
                                   }
        };

        openWeatherLoaderMock.Setup(x => x.GetWeatherForecastAsync(cityName.Value, cancellationToken))
                             .ReturnsAsync(dtoTest);

        var forecastConverterMock = new Mock<IForecastConverter>(MockBehavior.Strict);
        forecastConverterMock.Setup(x => x.Convert(dtoTest))
                             .Returns(expectedWeatherForecast);

        var loggerMock = new Mock<ILogger<WeatherForecastService>>();

        var service = new WeatherForecastService(openWeatherLoaderMock.Object, forecastConverterMock.Object, loggerMock.Object);

        // Act
        var result = await service.LoadWeatherForecastAsync(cityName, cancellationToken);

        // Assert
        result.Should().Be(expectedWeatherForecast);
    }
}
