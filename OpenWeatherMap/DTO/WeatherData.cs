using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

/// <summary>
/// Represents weather data returned by the OpenWeatherMap API for a specific date and time.
/// </summary>
public class WeatherData
{
    /// <summary>
    /// The date and time of the weather data in UTC.
    /// </summary>
    [JsonPropertyName("dt_txt")]
    public string DateText { get; set; } = default!;

    /// <summary>
    /// The wind data.
    /// </summary>
    [JsonPropertyName("wind")]
    public WindData Wind { get; set; } = default!;

    /// <summary>
    /// The main temperature data.
    /// </summary>
    [JsonPropertyName("main")]
    public MainData Main { get; set; } = default!;

    /// <summary>
    /// The list of weather conditions.
    /// </summary>
    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; } = default!;
}

