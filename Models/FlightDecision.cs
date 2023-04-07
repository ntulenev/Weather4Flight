namespace Models;

/// <summary>
/// Represents the decision whether a flight is recommended or not, along with the reasons for the decision.
/// </summary>
/// <param name="Recomendation">General flight recomendation.</param>
/// <param name="Reasons">Reasons for recomendation.</param>
public record FlightDecision(FlightRecomendation Recomendation, NoFlightReasons Reasons);
