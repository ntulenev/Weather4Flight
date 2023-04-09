using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

public class WindData
{
    [JsonPropertyName("speed")]
    public double Speed { get; set; }
}
