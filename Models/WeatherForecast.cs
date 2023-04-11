namespace Models;

/// <summary>
/// Represents a weather forecast for a city.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Gets the name of the city.
    /// </summary>
    public CityName CityName { get; }

    /// <summary>
    /// Gets the collection of weather conditions for the forecast.
    /// </summary>
    public IReadOnlyDictionary<DateTimeOffset, Weather> WeatherConditions => _weatherConditions;

    private readonly Dictionary<DateTimeOffset, Weather> _weatherConditions;

    /// <summary>
    /// Creates a new instance of the <see cref="WeatherForecast"/> class.
    /// </summary>
    /// <param name="cityName">The name of the city for the forecast.</param>
    /// <param name="weatherConditions">The collection of weather conditions for the forecast.</param>
    /// <exception cref="ArgumentNullException">Thrown if the city name or weather conditions are null.</exception>
    public WeatherForecast(CityName cityName, Dictionary<DateTimeOffset, Weather> weatherConditions)
    {
        ArgumentNullException.ThrowIfNull(cityName);
        ArgumentNullException.ThrowIfNull(weatherConditions);

        CityName = cityName;
        _weatherConditions = weatherConditions;
    }
}
