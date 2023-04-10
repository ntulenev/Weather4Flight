using System.Net;

using FluentAssertions;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Moq;
using Moq.Protected;

using OpenWeatherMap.Configuration;
using OpenWeatherMap.DTO;
using OpenWeatherMap.Exceptions;
using OpenWeatherMap.Logic;
using OpenWeatherMap.Serialization;

namespace OpenWeatherMap.Tests;

public class OpenWeatherLoaderTests
{
    [Fact(DisplayName = "OpenWeatherLoader should throw when httpClient is null")]
    public void OpenWeatherLoader_Should_Throw_When_HttpClient_Is_Null()
    {
        // Arrange
        var options = new Mock<IOptions<OpenWeatherMapConfiguration>>();
        options.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "key", ApiUrl = "url" });
        var jsonSerializer = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var logger = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        // Act
        Action act = () => _ = new OpenWeatherLoader(null!, options.Object, jsonSerializer.Object, logger.Object);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "OpenWeatherLoader should throw when options is null")]
    public void OpenWeatherLoader_Should_Throw_When_Options_Is_Null()
    {
        // Arrange
        var httpClient = new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object);
        var jsonSerializer = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var logger = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        // Act
        Action act = () => _ = new OpenWeatherLoader(httpClient, null!, jsonSerializer.Object, logger.Object);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "OpenWeatherLoader should throw when jsonSerializer is null")]
    public void OpenWeatherLoader_Should_Throw_When_JsonSerializer_Is_Null()
    {
        // Arrange
        var httpClient = new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object);
        var options = new Mock<IOptions<OpenWeatherMapConfiguration>>();
        options.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "key", ApiUrl = "url" });
        var logger = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        // Act
        Action act = () => _ = new OpenWeatherLoader(httpClient, options.Object, null!, logger.Object);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "OpenWeatherLoader should throw when logger is null")]
    public void OpenWeatherLoader_Should_Throw_When_Logger_Is_Null()
    {
        // Arrange
        var httpClient = new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object);
        var options = new Mock<IOptions<OpenWeatherMapConfiguration>>();
        options.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "key", ApiUrl = "url" });
        var jsonSerializer = new Mock<IJsonSerializer>(MockBehavior.Strict);

        // Act
        Action act = () => _ = new OpenWeatherLoader(httpClient, options.Object, jsonSerializer.Object, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }


    [Fact(DisplayName = "OpenWeatherLoader should throw when options value is not set")]
    public void OpenWeatherLoader_Should_Throw_When_Options_Value_Is_Not_Set()
    {
        // Arrange
        var httpClient = new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object);
        var options = new Mock<IOptions<OpenWeatherMapConfiguration>>();
        options.SetupGet(x => x.Value).Returns((OpenWeatherMapConfiguration)null!);
        var jsonSerializer = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var logger = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        // Act
        Action act = () => _ = new OpenWeatherLoader(httpClient, options.Object, jsonSerializer.Object, logger.Object);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact(DisplayName = "OpenWeatherLoader should create object when valid params are provided")]
    public void OpenWeatherLoader_Should_Create_Object_When_Valid_Params_Are_Provided()
    {
        // Arrange
        var httpClient = new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object);
        var options = new Mock<IOptions<OpenWeatherMapConfiguration>>();
        options.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "key", ApiUrl = "url" });
        var jsonSerializer = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var logger = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        // Act
        var loader = new OpenWeatherLoader(httpClient, options.Object, jsonSerializer.Object, logger.Object);

        // Assert
        loader.Should().NotBeNull();
    }

    [Fact(DisplayName = "GetWeatherForecastAsync should throw ArgumentNullException when city parameter is null")]
    public async Task GetWeatherForecastAsync_Should_Throw_ArgumentNullException_When_City_Parameter_Is_Null()
    {
        // Arrange
        var httpClientMock = new Mock<HttpClient>(MockBehavior.Strict);
        var optionsMock = new Mock<IOptions<OpenWeatherMapConfiguration>>(MockBehavior.Strict);
        optionsMock.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "test", ApiUrl = "test" });
        var jsonSerializerMock = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var loggerMock = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        var loader = new OpenWeatherLoader(
             httpClientMock.Object,
             optionsMock.Object,
             jsonSerializerMock.Object,
             loggerMock.Object);

        string city = null!;

        // Act
        Func<Task> act = async () => await loader.GetWeatherForecastAsync(city);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact(DisplayName = "GetWeatherForecastAsync should throw ArgumentException when city parameter is empty")]
    public async Task GetWeatherForecastAsync_Should_Throw_ArgumentException_When_City_Parameter_Is_Empty()
    {
        // Arrange
        var httpClientMock = new Mock<HttpClient>(MockBehavior.Strict);
        var optionsMock = new Mock<IOptions<OpenWeatherMapConfiguration>>(MockBehavior.Strict);
        optionsMock.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "test", ApiUrl = "test" });
        var jsonSerializerMock = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var loggerMock = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        var loader = new OpenWeatherLoader(
             httpClientMock.Object,
             optionsMock.Object,
             jsonSerializerMock.Object,
             loggerMock.Object);

        string city = string.Empty;

        // Act
        Func<Task> act = async () => await loader.GetWeatherForecastAsync(city);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact(DisplayName = "GetWeatherForecastAsync should throw ArgumentException when city parameter is whitespace")]
    public async Task GetWeatherForecastAsync_Should_Throw_ArgumentException_When_City_Parameter_Is_Whitespace()
    {
        // Arrange
        var httpClientMock = new Mock<HttpClient>(MockBehavior.Strict);
        var optionsMock = new Mock<IOptions<OpenWeatherMapConfiguration>>(MockBehavior.Strict);
        optionsMock.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "test", ApiUrl = "test" });
        var jsonSerializerMock = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var loggerMock = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        var loader = new OpenWeatherLoader(
             httpClientMock.Object,
             optionsMock.Object,
             jsonSerializerMock.Object,
             loggerMock.Object);
        string city = "  ";

        // Act
        Func<Task> act = async () => await loader.GetWeatherForecastAsync(city);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact(DisplayName = "GetWeatherForecastAsync should throw OperationCanceledException when cancellation token is canceled")]
    public async Task GetWeatherForecastAsync_Should_Throw_OperationCanceledException_When_CancellationToken_Is_Canceled()
    {
        // Arrange
        var httpClientMock = new Mock<HttpClient>(MockBehavior.Strict);
        var optionsMock = new Mock<IOptions<OpenWeatherMapConfiguration>>(MockBehavior.Strict);
        optionsMock.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = "test", ApiUrl = "test" });
        var jsonSerializerMock = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var loggerMock = new Mock<ILogger<OpenWeatherLoader>>(MockBehavior.Strict);

        var loader = new OpenWeatherLoader(
             httpClientMock.Object,
             optionsMock.Object,
             jsonSerializerMock.Object,
             loggerMock.Object);
        var cancellationToken = new CancellationToken(true);

        // Act
        Func<Task> act = async () => await loader.GetWeatherForecastAsync("London", cancellationToken);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }

    [Fact(DisplayName = "GetWeatherForecastAsync should throw OpenWeatherMapException when HTTP response is not successful")]
    public async Task GetWeatherForecastAsync_Should_Throw_OpenWeatherMapException_When_HTTP_Response_Is_Not_Successful()
    {
        // Arrange
        var optionsMock = new Mock<IOptions<OpenWeatherMapConfiguration>>(MockBehavior.Strict);
        var jsonSerializerMock = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var loggerMock = new Mock<ILogger<OpenWeatherLoader>>();

        var city = "London";
        var cancellationToken = CancellationToken
                .None;
        var apiUrl = "https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}";
        var apiKey = "test-api-key";
        var url = string.Format(apiUrl, city, apiKey);
        var responseBody = "Error retrieving weather forecast";

        optionsMock.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = apiKey, ApiUrl = apiUrl });
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(a => a.Method.ToString() == "GET" && a.RequestUri!.ToString() == url),
                ItExpr.IsAny<CancellationToken>()
            )
           .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest)
           {
               Content = new StringContent(responseBody)
           });

        jsonSerializerMock.Setup(x => x.Deserialize<WeatherForecast>(responseBody)).Returns((WeatherForecast)null!);
        var loader = new OpenWeatherLoader(
            new HttpClient(handlerMock.Object),
            optionsMock.Object,
            jsonSerializerMock.Object,
            loggerMock.Object);

        // Act
        Func<Task> act = async () => await loader.GetWeatherForecastAsync(city, cancellationToken);

        // Assert
        await act.Should().ThrowAsync<OpenWeatherMapException>();
    }

    [Fact(DisplayName = "GetWeatherForecastAsync should return WeatherForecast when HTTP response is successful")]
    public async Task GetWeatherForecastAsync_Should_Return_WeatherForecast_When_HTTP_Response_Is_Successful()
    {
        // Arrange
        var optionsMock = new Mock<IOptions<OpenWeatherMapConfiguration>>(MockBehavior.Strict);
        var jsonSerializerMock = new Mock<IJsonSerializer>(MockBehavior.Strict);
        var loggerMock = new Mock<ILogger<OpenWeatherLoader>>();

        var city = "London";
        var cancellationToken = CancellationToken.None;
        var apiUrl = "https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}";
        var apiKey = "test-api-key";
        var url = string.Format(apiUrl, city, apiKey);
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        var responseBody = "response body";
        var weatherForecast = new WeatherForecast();
        response.Content = new StringContent(responseBody);

        optionsMock.SetupGet(x => x.Value).Returns(new OpenWeatherMapConfiguration { ApiKey = apiKey, ApiUrl = apiUrl });
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(a => a.Method.ToString() == "GET" && a.RequestUri!.ToString() == url),
                ItExpr.IsAny<CancellationToken>()
            )
           .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
           {
               Content = new StringContent(responseBody)
           });
        jsonSerializerMock.Setup(x => x.Deserialize<WeatherForecast>(responseBody)).Returns(weatherForecast);

        var loader = new OpenWeatherLoader(
             new HttpClient(handlerMock.Object),
             optionsMock.Object,
             jsonSerializerMock.Object,
             loggerMock.Object);

        // Act
        var result = await loader.GetWeatherForecastAsync(city, cancellationToken);

        // Assert
        result.Should().Be(weatherForecast);
    }
}