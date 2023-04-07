namespace Models;

/// <summary>
/// Represents the type of precipitation in weather data.
/// </summary>
public enum PrecipitationType
{
    /// <summary>
    /// No precipitation.
    /// </summary>
    None,
    /// <summary>
    /// Light, fine rain.
    /// </summary>
    Drizzle,
    /// <summary>
    /// Raindrops falling from the sky.
    /// </summary>
    Rain,
    /// <summary>
    /// Snowflakes falling from the sky.
    /// </summary>
    Snow,
    /// <summary>
    /// A mix of snow and rain falling from the sky.
    /// </summary>
    SnowAndRain,
    /// <summary>
    /// Rain that freezes on contact with the ground or objects.
    /// </summary>
    FreezingRain,
    /// <summary>
    /// Drizzle that freezes on contact with the ground or objects.
    /// </summary>
    FreezingDrizzle,
    /// <summary>
    /// Brief, intense rain showers.
    /// </summary>
    ShowerRain,
    /// <summary>
    /// Precipitation in the form of small balls or lumps of ice.
    /// </summary>
    Hail,
    /// <summary>
    /// Small, soft pellets of ice that fall from the sky.
    /// </summary>
    SmallHail,
    /// <summary>
    /// A storm characterized by thunder and lightning, usually with rain and sometimes with hail or strong winds.
    /// </summary>
    Thunderstorm,
    /// <summary>
    /// A fine spray or light fog caused by water droplets in the air.
    /// </summary>
    Mist,
    /// <summary>
    /// Particles of solid or liquid matter suspended in the air, typically caused by smoke or smog.
    /// </summary>
    Smoke,
    /// <summary>
    /// A slight obscuration of the lower atmosphere, typically caused by fine dust.
    /// </summary>
    Haze,
    /// <summary>
    /// Fine, dry particles of earth or sand lifted up by the wind.
    /// </summary>
    Sand,
    /// <summary>
    /// Fine, dry particles of earth or sand lifted up by the wind.
    /// </summary>
    Dust,
    /// <summary>
    /// Thick mist or fog that makes it difficult to see more than a short distance.
    /// </summary>
    Foggy,
    /// <summary>
    /// Brief, strong gusts of wind accompanied by rain or snow.
    /// </summary>
    Squalls,
    /// <summary>
    /// A violent, dangerous rotating column of air that is in contact with both the surface of the earth and a cumulonimbus cloud.
    /// </summary>
    Tornado,
    /// <summary>
    /// Other or unknown type of precipitation.
    /// </summary>
    Other
}
