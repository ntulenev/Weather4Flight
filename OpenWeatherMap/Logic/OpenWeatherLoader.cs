using Microsoft.Extensions.Options;

using OpenWeatherMap.Configuration;
using OpenWeatherMap.DTO;

using System.Text.Json;

namespace OpenWeatherMap.Logic;

/// <summary>
/// Loads weather forecast from the OpenWeatherMap API using the provided API key and city name.
/// </summary>
public class OpenWeatherLoader : IOpenWeatherLoader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OpenWeatherLoader"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client used to make API requests.</param>
    /// <param name="options">The options containing the OpenWeatherMap API key and URL.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when the httpClient or options parameters are null.</exception>
    /// <exception cref="System.ArgumentException">Thrown when the options value is not set.</exception>
    public OpenWeatherLoader(HttpClient httpClient, IOptions<OpenWeatherMapConfiguration> options)
    {

        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(options);

        if (options.Value is null)
        {
            throw new ArgumentException("Options value is not set", nameof(options));
        }

        _httpClient = httpClient;
        _apiKey = options.Value.ApiKey;
        _apiPath = options.Value.ApiUrl;
    }

    /// <inheritdoc/>
    /// <exception cref="System.ArgumentNullException">Thrown when the city parameter is null.</exception>
    /// <exception cref="System.ArgumentException">Thrown when the city parameter is empty or whitespace.</exception>
    public async Task<WeatherForecast> GetWeatherForecastAsync(string city, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(city);
        ArgumentException.ThrowIfNullOrEmpty(city);

        cancellationToken.ThrowIfCancellationRequested();

        var url = string.Format(_apiPath, city, _apiKey);

        HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

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

    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiPath;
}
