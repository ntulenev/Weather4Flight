namespace Models;

/// <summary>
/// Represents the speed of the wind.
/// </summary>
public class WindSpeed
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindSpeed"/> class.
    /// </summary>
    /// <param name="value">The speed of the wind in km/h.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the wind speed value is negative.</exception>
    public WindSpeed(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Wind speed value cannot be negative.");
        }

        Value = value;
    }

    /// <summary>
    /// Gets the speed of the wind in km/h.
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// Gets a value indicating whether the wind is strong or not.
    /// </summary>
    /// <remarks>
    /// Strong wind is defined as wind speed greater than or equal to <see cref="StrongWindThreshold"/>.
    /// </remarks>
    public bool IsStrongWind => Value >= StrongWindThreshold;

    /// <summary>
    /// Set the threshold for strong wind.
    /// </summary>
    private const decimal StrongWindThreshold = 25m;
}

