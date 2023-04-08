namespace Models
{
    /// <summary>
    /// Represents the decision whether a flight is recommended or not, along with the reasons for the decision.
    /// </summary>
    public class FlightDecision
    {
        /// <summary>
        /// Gets the general flight recommendation.
        /// </summary>
        public FlightRecomendation Recomendation { get; }

        /// <summary>
        /// Gets the reasons for the flight recommendation.
        /// </summary>
        public NoFlightReasons Reasons { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightDecision"/> class with the specified recommendation and reasons.
        /// </summary>
        /// <param name="recomendation">The general flight recommendation.</param>
        /// <param name="reasons">The reasons for the flight recommendation.</param>
        /// <exception cref="ArgumentException">Thrown when recommendation is BadForFlight but reasons is None.</exception>
        public FlightDecision(FlightRecomendation recomendation, NoFlightReasons reasons)
        {
            if (recomendation == FlightRecomendation.BadForFlight && reasons == NoFlightReasons.None)
            {
                throw new ArgumentException("When recommendation is BadForFlight, reasons must be specified.");
            }

            Recomendation = recomendation;
            Reasons = reasons;
        }
    }
}
