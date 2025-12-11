using Models;

using System.Text.Json.Serialization;

namespace WebAPI.DTO;

/// <summary>
/// Represents weather flight data.
/// </summary>
public class WeatherFlightData
{
    /// <summary>
    /// Gets or sets the date and time of the weather flight data.
    /// </summary>
    [JsonPropertyName("date")]
    public required DateTimeOffset Date { get; init; }

    /// <summary>
    /// Gets or sets the flight recommendation.
    /// </summary>
    [JsonPropertyName("recommendation")]
    public required FlightRecommendation Recommendation { get; init; }

    /// <summary>
    /// Gets or sets the reasons for the flight recommendation.
    /// </summary>
    [JsonPropertyName("reasons")]
    public required NoFlightReasons Reasons { get; init; }

    /// <summary>
    /// Gets or sets the precipitation type.
    /// </summary>
    [JsonPropertyName("precipitations")]
    public required PrecipitationType Precipitations { get; init; }

    /// <summary>
    /// Gets or sets the temperature.
    /// </summary>
    [JsonPropertyName("temperature")]
    public required decimal Temperature { get; init; }

    /// <summary>
    /// Gets or sets the wind speed.
    /// </summary>
    [JsonPropertyName("windSpeed")]
    public required decimal WindSpeed { get; init; }
}
