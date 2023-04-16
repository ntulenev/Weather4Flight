using System.Text.Json.Serialization;

namespace WebAPI.DTO;

/// <summary>
/// Represents a flight forecast DTO.
/// </summary>
public class FlightForecast
{
    /// <summary>
    /// Gets the weather flight data.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<WeatherFlightData> Data { get; }

    private FlightForecast(IEnumerable<WeatherFlightData> data)
    {
        Data = data;
    }

    /// <summary>
    /// Creates a flight forecast DTO from a weather forecast model.
    /// </summary>
    /// <param name="weatherForecast">The weather forecast model.</param>
    /// <returns>The flight forecast DTO.</returns>
    /// <exception cref="ArgumentNullException">Thrown when weatherForecast is null.</exception>
    public static FlightForecast CreateFromModel(Models.WeatherForecast weatherForecast)
    {
        ArgumentNullException.ThrowIfNull(weatherForecast);

        return new FlightForecast(from data in weatherForecast.WeatherConditions
                                  let flightData = data.Value.CreateFlightDecision()
                                  let Value = data.Value
                                  select new WeatherFlightData
                                  {
                                      Date = data.Key,
                                      Reasons = flightData.Reasons,
                                      Recomendation = flightData.Recomendation,
                                      Temperature = Value.Temperature.Value,
                                      WindSpeed = Value.WindSpeed.Value,
                                      Precipitations = Value.Precipitations
                                  });
    }
}
