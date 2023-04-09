using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

public class MainData
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }
}
