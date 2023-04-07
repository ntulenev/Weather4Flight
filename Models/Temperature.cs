namespace Models;

/// <summary>
/// Represents a temperature value.
/// </summary>
public class Temperature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Temperature"/> class with the specified value.
    /// </summary>
    /// <param name="value">The temperature value in degrees Celsius.</param>
    /// <exception cref="ArgumentException">Thrown when the temperature is below absolute zero (-273.15°C).</exception>
    public Temperature(decimal value)
    {
        if (value < AbsoluteZero)
        {
            throw new ArgumentException($"Temperature cannot be below absolute zero ({AbsoluteZero}°C)");
        }

        _value = value;
    }

    /// <summary>
    /// Gets the temperature value in degrees Celsius.
    /// </summary>
    public decimal Value => _value;

    /// <summary>
    /// Gets the temperature category based on the temperature value.
    /// </summary>
    public TemperatureCategory Category
    {
        get
        {
            if (_value < ColdThreshold)
            {
                return TemperatureCategory.Cold;
            }
            else if (_value > HotThreshold)
            {
                return TemperatureCategory.Hot;
            }
            else
            {
                return TemperatureCategory.Normal;
            }
        }
    }

    private readonly decimal _value;
    private const decimal AbsoluteZero = -273.15M;
    private const decimal ColdThreshold = 0.0M;
    private const decimal HotThreshold = 35.0M;
}
