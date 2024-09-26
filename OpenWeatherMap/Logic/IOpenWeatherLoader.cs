using OpenWeatherMap.DTO;

namespace OpenWeatherMap.Logic;

/// <summary>
/// Represents a service for loading weather forecast data from OpenWeatherMap API.
/// </summary>
public interface IOpenWeatherLoader
{
    /// <summary>
    /// Asynchronously retrieves a weather forecast for the specified city.
    /// </summary>
    /// <param name="city">The name of the city to retrieve the forecast for.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation that returns a 
    /// <see cref="WeatherForecast"/> object.</returns>
    Task<WeatherForecast> GetWeatherForecastAsync(string city, CancellationToken cancellationToken = default);
}
