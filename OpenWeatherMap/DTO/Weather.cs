using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

public class Weather
{
    [JsonPropertyName("main")]
    public string Main { get; set; } = default!;
}
