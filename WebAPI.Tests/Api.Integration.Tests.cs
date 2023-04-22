using FluentAssertions;

using Microsoft.AspNetCore.Mvc.Testing;

using System.Net;

namespace WebAPI.Tests;

public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory(DisplayName = "Get weather forecast valid response status for a city")]
    [Trait("Category", "Integration")]
    [InlineData("New York")]
    [InlineData("London")]
    public async Task Get_WeatherForecast_ReturnsValidStatus(string cityName)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/weather/{cityName}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}