using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

/// <summary>
/// Represents the weather data returned by the OpenWeatherMap API.
/// </summary>
public class Weather
{
    /// <summary>
    /// The main weather condition.
    /// </summary>
    [JsonPropertyName("main")]
    public string Main { get; set; } = default!;
}
