using Models;

namespace Abstractions;

/// <summary>
/// Represents a service that can load weather forecasts for cities.
/// </summary>
public interface IWeatherForecastService
{
    /// <summary>
    /// Asynchronously loads the weather forecast for the specified city.
    /// </summary>
    /// <param name="cityName">The name of the city to load the forecast for.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. 
    /// The result of the task contains the weather forecast for the specified city.</returns>
    Task<WeatherForecast> LoadWeatherForecastAsync(CityName cityName, CancellationToken cancellationToken);
}
