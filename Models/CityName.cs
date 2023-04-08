namespace Models;

/// <summary>
/// Represents the name of a city.
/// </summary>
public class CityName
{
    /// <summary>
    /// Gets the value of the city name.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="CityName"/> class.
    /// </summary>
    /// <param name="value">The value of the city name.</param>
    /// <exception cref="ArgumentException">Thrown when the city name is null or empty.</exception>
    public CityName(string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("City name cannot be null or empty");
        }

        Value = value;
    }
}
