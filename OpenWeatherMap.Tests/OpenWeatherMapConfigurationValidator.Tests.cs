using Microsoft.Extensions.Options;

using OpenWeatherMap.Configuration;
using OpenWeatherMap.Configuration.Validation;

using FluentAssertions;

namespace OpenWeatherMap.Tests;

public class OpenWeatherMapConfigurationValidatorTests
{
    [Theory(DisplayName = "Validate should return failure result when ApiKey is null or empty")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_Should_Return_Failure_Result_When_ApiKey_Is_Null_Or_Empty(string apiKey)
    {
        // Arrange
        var validator = new OpenWeatherMapConfigurationValidator();
        var options = new OpenWeatherMapConfiguration { ApiKey = apiKey, ApiUrl = "test" };

        // Act
        var result = validator.Validate(null, options);

        // Assert
        result.Failed.Should().BeTrue();
    }

    [Theory(DisplayName = "Validate should return failure result when ApiUrl is null or empty")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_Should_Return_Failure_Result_When_ApiUrl_Is_Null_Or_Empty(string apiUrl)
    {
        // Arrange
        var validator = new OpenWeatherMapConfigurationValidator();
        var options = new OpenWeatherMapConfiguration { ApiKey = "abcd", ApiUrl = apiUrl };

        // Act
        var result = validator.Validate(null, options);

        // Assert
        result.Failed.Should().BeTrue();
    }

    [Fact(DisplayName = "Validate should return success result when options are valid")]
    public void Validate_Should_Return_Success_Result_When_Options_Are_Valid()
    {
        // Arrange
        var validator = new OpenWeatherMapConfigurationValidator();
        var options = new OpenWeatherMapConfiguration
        {
            ApiKey = "1234567890abcdef",
            ApiUrl = "http://api.openweathermap.org/data/2.5/weather"
        };

        // Act
        var result = validator.Validate(null, options);

        // Assert
        result.Should().Be(ValidateOptionsResult.Success);
    }
}
