using OpenWeatherMap.Configuration;

using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class OpenWeatherMapConfigurationTests
{
    [Fact(DisplayName = "OpenWeatherMapConfiguration should be instantiated with properties set correctly")]
    [Trait("Category", "Unit")]
    public void OpenWeatherMapConfiguration_Should_Be_Instantiated_With_Properties_Set_Correctly()
    {
        // Arrange
        var expectedApiKey = "1234567890abcdef";
        var expectedApiUrl = "http://api.openweathermap.org/data/2.5/weather";

        // Act
        var config = new OpenWeatherMapConfiguration
        {
            ApiKey = expectedApiKey,
            ApiUrl = expectedApiUrl
        };

        // Assert
        config.ApiKey.Should().Be(expectedApiKey);
        config.ApiUrl.Should().Be(expectedApiUrl);
    }
}

