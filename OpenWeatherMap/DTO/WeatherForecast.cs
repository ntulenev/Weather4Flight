using System.Text.Json.Serialization;

namespace OpenWeatherMap.DTO
{
    public class WeatherForecast
    {
        [JsonPropertyName("city")]
        public City City { get; set; } = default!;

        [JsonPropertyName("list")]
        public List<WeatherData> WeatherDataList { get; set; } = default!;
    }
}
