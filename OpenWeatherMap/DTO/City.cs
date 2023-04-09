using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

public class City
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}
