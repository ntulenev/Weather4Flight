using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

/// <summary>
/// Represents wind data returned by the OpenWeatherMap API.
/// </summary>
public class WindData
{
    /// <summary>
    /// The wind speed in meters per second.
    /// </summary>
    [JsonPropertyName("speed")]
    public double Speed { get; set; }
}

