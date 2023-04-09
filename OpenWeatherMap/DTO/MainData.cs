using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

/// <summary>
/// Represents the main temperature data returned by the OpenWeatherMap API.
/// </summary>
public class MainData
{
    /// <summary>
    /// The temperature in Celsius.
    /// </summary>
    [JsonPropertyName("temp")]
    public double Temp { get; set; }
}

