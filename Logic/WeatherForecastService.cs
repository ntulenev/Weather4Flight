using Abstractions;
using Models;
using OpenWeatherMap.Logic;

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
    /// <param name="forecastConverter">The converter used to convert the weather forecast data to a WeatherForecast object.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if either the openWeatherLoader or forecastConverter parameter is null.</exception>
    public WeatherForecastService(IOpenWeatherLoader openWeatherLoader, IForecastConverter forecastConverter)
    {
        _openWeatherLoader = openWeatherLoader ?? throw new ArgumentNullException(nameof(openWeatherLoader));
        _forecastConverter = forecastConverter ?? throw new ArgumentNullException(nameof(forecastConverter));
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

        var forecast = await _openWeatherLoader.GetWeatherForecastAsync(cityName.Value, cancellationToken);
        return _forecastConverter.Convert(forecast);
    }

    private readonly IOpenWeatherLoader _openWeatherLoader;
    private readonly IForecastConverter _forecastConverter;
}
