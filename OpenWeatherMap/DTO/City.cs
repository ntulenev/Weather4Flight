using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

/// <summary>
/// Represents a city returned by the OpenWeatherMap API.
/// </summary>
public class City
{
    /// <summary>
    /// The name of the city.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}

