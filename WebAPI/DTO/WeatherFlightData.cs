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
    public DateTimeOffset Date { get; set; }

    /// <summary>
    /// Gets or sets the flight recommendation.
    /// </summary>
    [JsonPropertyName("recomendation")]
    public FlightRecomendation Recomendation { get; set; }

    /// <summary>
    /// Gets or sets the reasons for the flight recommendation.
    /// </summary>
    [JsonPropertyName("reasons")]
    public NoFlightReasons Reasons { get; set; }

    /// <summary>
    /// Gets or sets the precipitation type.
    /// </summary>
    [JsonPropertyName("precipitations")]
    public PrecipitationType Precipitations { get; set; }

    /// <summary>
    /// Gets or sets the temperature.
    /// </summary>
    [JsonPropertyName("temperature")]
    public decimal Temperature { get; set; }

    /// <summary>
    /// Gets or sets the wind speed.
    /// </summary>
    [JsonPropertyName("windSpeed")]
    public decimal WindSpeed { get; set; }
}
