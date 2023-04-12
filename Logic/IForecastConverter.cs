using DTO = OpenWeatherMap.DTO;

namespace Logic;

/// <summary>
/// Converts a DTO weather forecast to a model weather forecast.
/// </summary>
public interface IForecastConverter
{
    /// <summary>
    /// Converts a DTO weather forecast to a model weather forecast.
    /// </summary>
    /// <param name="weatherForecast">The DTO weather forecast to convert.</param>
    /// <returns>The converted model weather forecast.</returns>
    Models.WeatherForecast Convert(DTO.WeatherForecast weatherForecast);
}
