using Microsoft.Extensions.Logging;
using Models;
using System.Globalization;
using DTO = OpenWeatherMap.DTO;

namespace Logic;

/// <summary>
/// Converts an OpenWeatherMap.DTO.WeatherForecast object to a Logic.Models.WeatherForecast object.
/// </summary>
public class ForecastConverter : IForecastConverter
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForecastConverter"/> class.
    /// </summary>
    /// <param name="logger">The logger to use for logging messages.</param>
    /// <exception cref="ArgumentNullException">Thrown when the logger is null.</exception>
    public ForecastConverter(ILogger<ForecastConverter> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Converts an OpenWeatherMap.DTO.WeatherForecast object to a Logic.Models.WeatherForecast object.
    /// </summary>
    /// <param name="weatherForecast">The OpenWeatherMap.DTO.WeatherForecast object to convert.</param>
    /// <returns>A Logic.Models.WeatherForecast object.</returns>
    public WeatherForecast Convert(DTO.WeatherForecast weatherForecast)
    {
        ArgumentNullException.ThrowIfNull(weatherForecast);

        var data = from row in weatherForecast.WeatherDataList
                   select new
                   {
                       Date = ConvertDtTxtToDateTimeOffset(row.DateText),
                       Weather = new Weather(
                           new Temperature((decimal)row.Main.Temp),
                           new WindSpeed((decimal)row.Wind.Speed),
                           CombinePrecipitationTypes(row.Weather.Select(x => ConvertToPrecipitationType(x.Main)))
                           )
                   };

        var weather = data.ToDictionary(x => x.Date, x => x.Weather);

        return new WeatherForecast(new CityName(weatherForecast.City.Name), weather);
    }

    private static PrecipitationType CombinePrecipitationTypes(IEnumerable<PrecipitationType> precipitationTypes)
    {
        return precipitationTypes.Aggregate((combined, current) => combined | current);
    }

    private static DateTimeOffset ConvertDtTxtToDateTimeOffset(string dtTxt)
    {
        // Parse the dtTxt string as a DateTime object using the ISO 8601 format
        DateTime dateTimeUtc = DateTime.ParseExact(dtTxt, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

        // Convert the DateTime to a DateTimeOffset object with the UTC offset
        DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTimeUtc, TimeSpan.Zero);

        return dateTimeOffset;
    }

    private PrecipitationType ConvertToPrecipitationType(string weatherCondition)
    {
        var precipitationType = weatherCondition.ToLower() switch
        {
            "none" or "clear" => PrecipitationType.None,
            "clouds" => PrecipitationType.Clouds,
            "drizzle" => PrecipitationType.Drizzle,
            "rain" => PrecipitationType.Rain,
            "snow" => PrecipitationType.Snow,
            "sleet" => PrecipitationType.SnowAndRain,
            "freezing rain" => PrecipitationType.FreezingRain,
            "freezing drizzle" => PrecipitationType.FreezingDrizzle,
            "shower rain" => PrecipitationType.ShowerRain,
            "hail" => PrecipitationType.Hail,
            "small hail" => PrecipitationType.SmallHail,
            "thunderstorm" => PrecipitationType.Thunderstorm,
            _ => PrecipitationType.Other,
        };

        if (precipitationType == PrecipitationType.Other)
        {
            _logger.LogWarning("Unknown weather condition: {weatherCondition}", weatherCondition);
        }

        return precipitationType;
    }

    private readonly ILogger<ForecastConverter> _logger;
}
