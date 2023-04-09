using OpenWeatherMap.DTO;

namespace OpenWeatherMap.Logic;

public interface IOpenWeatherLoader
{
    Task<WeatherForecast> GetWeatherForecastAsync(string city, CancellationToken cancellationToken = default);
}
