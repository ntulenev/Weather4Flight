namespace Models;

/// <summary>
/// Represents the recommendation regarding whether a flight should be taken or not.
/// </summary>
public enum FlightRecommendation
{
    /// <summary>
    /// Indicates that conditions are good for flying.
    /// </summary>
    GoodForFlight,

    /// <summary>
    /// Indicates that conditions are not good for flying.
    /// </summary>
    BadForFlight,
}
