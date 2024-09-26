using Abstractions;
using Models;
using OpenWeatherMap.Logic;

using Microsoft.Extensions.Logging;

namespace Logic;

/// <summary>
/// Implements the IWeatherForecastService interface to load a weather forecast for a given city.
/// </summary>
public class WeatherForecastService : IWeatherForecastService
{
    /// <summary>
    /// Initializes a new instance of the WeatherForecastService class with the specified dependencies.
    /// </summary>
    /// <param name="openWeatherLoader">The loader used to get the weather forecast data.</param>
    /// <param name="forecastConverter">The converter used to convert the weather forecast 
    /// data to a WeatherForecast object.</param>
    /// <param name="logger">The logger used to log information and errors.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if either the 
    /// openWeatherLoader, forecastConverter, or logger parameter is null.</exception>
    public WeatherForecastService(
        IOpenWeatherLoader openWeatherLoader, 
        IForecastConverter forecastConverter, 
        ILogger<WeatherForecastService> logger)
    {
        _openWeatherLoader = openWeatherLoader ?? throw new ArgumentNullException(nameof(openWeatherLoader));
        _forecastConverter = forecastConverter ?? throw new ArgumentNullException(nameof(forecastConverter));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Loads a weather forecast for the specified city.
    /// </summary>
    /// <param name="cityName">The name of the city for which to load the weather forecast.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A WeatherForecast object representing the weather forecast for the specified city.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown if the cityName parameter is null.</exception>
    public async Task<WeatherForecast> LoadWeatherForecastAsync(CityName cityName, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(cityName);

        _logger.LogInformation("Loading weather forecast for {CityName}", cityName.Value);

        try
        {
            var forecast = await _openWeatherLoader.GetWeatherForecastAsync(cityName.Value, cancellationToken);
            return _forecastConverter.Convert(forecast);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading weather forecast for {CityName}", cityName.Value);
            throw;
        }
    }

    private readonly IOpenWeatherLoader _openWeatherLoader;
    private readonly IForecastConverter _forecastConverter;
    private readonly ILogger<WeatherForecastService> _logger;
}
