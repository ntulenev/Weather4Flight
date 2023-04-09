using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

/// <summary>
/// Represents a weather forecast returned by the OpenWeatherMap API.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// The city for which the weather forecast is for.
    /// </summary>
    [JsonPropertyName("city")]
    public City City { get; set; } = default!;

    /// <summary>
    /// The list of weather data for the forecast.
    /// </summary>
    [JsonPropertyName("list")]
    public List<WeatherData> WeatherDataList { get; set; } = default!;
}

