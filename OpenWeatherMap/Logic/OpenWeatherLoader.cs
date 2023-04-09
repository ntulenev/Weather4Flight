using OpenWeatherMap.DTO;

using System.Text.Json;

namespace OpenWeatherMap.Logic;

public class OpenWeatherLoader : IOpenWeatherLoader
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OpenWeatherLoader(HttpClient httpClient, string apiKey)
    {
        // TODO Add validation
        // TODO Add Options<>
        _httpClient = httpClient;
        _apiKey = apiKey;
    }

    public async Task<WeatherForecast> GetWeatherForecastAsync(string city, CancellationToken cancellationToken = default)
    {
        // TODO Add validation
        // TODO Move url to Options config
        string url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}&units=metric";
        HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
        string responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<WeatherForecast>(responseBody)!;
        }
        else
        {
            // TODO Add custom exception type 
            throw new Exception($"Error retrieving weather forecast: {responseBody}");
        }
    }
}
