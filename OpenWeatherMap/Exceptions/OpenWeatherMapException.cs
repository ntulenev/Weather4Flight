namespace OpenWeatherMap.Exceptions;

/// <summary>
/// Exception thrown when an error occurs while retrieving weather data from the OpenWeatherMap API.
/// </summary>
public class OpenWeatherMapException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OpenWeatherMapException"/> class 
    /// with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public OpenWeatherMapException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenWeatherMapException"/> class 
    /// with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public OpenWeatherMapException(string message, Exception innerException) : base(message, innerException)
    {
    }
}



