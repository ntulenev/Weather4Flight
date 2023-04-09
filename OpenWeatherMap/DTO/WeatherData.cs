using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO;

public class WeatherData
{
    [JsonPropertyName("dt_txt")]
    public string DateText { get; set; } = default!;

    [JsonPropertyName("wind")]
    public WindData Wind { get; set; } = default!;

    [JsonPropertyName("main")]
    public MainData Main { get; set; } = default!;

    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; } = default!;
}
