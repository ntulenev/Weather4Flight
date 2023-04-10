using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using OpenWeatherMap.Configuration;
using OpenWeatherMap.DTO;
using OpenWeatherMap.Exceptions;
using OpenWeatherMap.Serialization;

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
    /// <param name="jsonSerializer">The JSON serializer used to deserialize the API response.</param>
    /// <param name="logger">The logger used for logging events during API requests.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when any parameter is null.</exception>
    /// <exception cref="System.ArgumentException">Thrown when the options value is not set.</exception>
    public OpenWeatherLoader(HttpClient httpClient,
                             IOptions<OpenWeatherMapConfiguration> options,
                             IJsonSerializer jsonSerializer,
                             ILogger<OpenWeatherLoader> logger)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(jsonSerializer);
        ArgumentNullException.ThrowIfNull(logger);

        if (options.Value is null)
        {
            throw new ArgumentException("Options value is not set", nameof(options));
        }

        _httpClient = httpClient;
        _apiKey = options.Value.ApiKey;
        _apiPath = options.Value.ApiUrl;
        _jsonSerializer = jsonSerializer;
        _logger = logger;
    }

    /// <inheritdoc/>
    /// <exception cref="System.ArgumentNullException">Thrown when the city parameter is null.</exception>
    /// <exception cref="System.ArgumentException">Thrown when the city parameter is empty or whitespace.</exception>
    /// <exception cref="OpenWeatherMapException">Thrown when an error occurs while retrieving weather data from the OpenWeatherMap API.</exception>

    public async Task<WeatherForecast> GetWeatherForecastAsync(string city, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(city);
        ArgumentException.ThrowIfNullOrEmpty(city);

        cancellationToken.ThrowIfCancellationRequested();

        var url = string.Format(_apiPath, city, _apiKey);

        _logger.LogInformation("URL {url}", url);

        HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

        _logger.LogInformation("Response IsSuccesess : {IsSuccessStatusCode} : {responseBody}", response.IsSuccessStatusCode, responseBody);

        if (response.IsSuccessStatusCode)
        {
            return _jsonSerializer.Deserialize<WeatherForecast>(responseBody)!;
        }
        else
        {
            throw new OpenWeatherMapException($"Error retrieving weather forecast: {responseBody}");
        }
    }

    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiPath;
    private readonly ILogger<OpenWeatherLoader> _logger;
    private readonly IJsonSerializer _jsonSerializer;
}
