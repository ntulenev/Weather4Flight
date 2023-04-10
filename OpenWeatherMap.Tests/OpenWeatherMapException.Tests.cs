using FluentAssertions;

using OpenWeatherMap.Exceptions;

namespace OpenWeatherMap.Tests;

public class OpenWeatherMapExceptionTests
{
    [Fact(DisplayName = "OpenWeatherMapException should be instantiated with a message")]
    public void OpenWeatherMapException_Should_Be_Instantiated_With_A_Message()
    {
        // Arrange
        var expectedMessage = "An error occurred while retrieving weather data from the OpenWeatherMap API.";

        // Act
        var exception = new OpenWeatherMapException(expectedMessage);

        // Assert
        exception.Message.Should().Be(expectedMessage);
        exception.InnerException.Should().BeNull();
    }

    [Fact(DisplayName = "OpenWeatherMapException should be instantiated with a message and an inner exception")]
    public void OpenWeatherMapException_Should_Be_Instantiated_With_A_Message_And_An_Inner_Exception()
    {
        // Arrange
        var expectedMessage = "An error occurred while retrieving weather data from the OpenWeatherMap API.";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new OpenWeatherMapException(expectedMessage, innerException);

        // Assert
        exception.Message.Should().Be(expectedMessage);
        exception.InnerException.Should().Be(innerException);
    }
}