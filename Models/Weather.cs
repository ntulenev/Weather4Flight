namespace Models
{
    /// <summary>
    /// Represents the weather conditions at a specific location.
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Gets the temperature of the location.
        /// </summary>
        public Temperature Temperature { get; }

        /// <summary>
        /// Gets the wind speed of the location.
        /// </summary>
        public WindSpeed WindSpeed { get; }

        /// <summary>
        /// Precipitations
        /// </summary>
        public PrecipitationType Precipitations { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weather"/> class.
        /// </summary>
        /// <param name="temperature">The temperature of the location.</param>
        /// <param name="pressure">The pressure of the location.</param>
        /// <param name="humidity">The humidity of the location.</param>
        /// <param name="windSpeed">The wind speed of the location.</param>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null.</exception>
        public Weather(Temperature temperature, WindSpeed windSpeed, PrecipitationType precipitations)
        {
            ArgumentNullException.ThrowIfNull(temperature);
            ArgumentNullException.ThrowIfNull(windSpeed);

            Temperature = temperature;
            WindSpeed = windSpeed;

            Precipitations = precipitations;
        }

        /// <summary>
        /// Determines whether flying is recommended based on the weather conditions.
        /// </summary>
        /// <returns>A <see cref="FlightDecision"/> object indicating whether flying is recommended, and if not, the reasons why.</returns>
        public FlightDecision CreateFlightDecision()
        {
            var reasons = (Temperature.Category switch
            {
                TemperatureCategory.Cold => NoFlightReasons.ColdTemperature,
                TemperatureCategory.Hot => NoFlightReasons.HotTemperature,
                _ => NoFlightReasons.None
            })
            |
            (WindSpeed.IsStrongWind ? NoFlightReasons.Wind : NoFlightReasons.None)
            |
            (Precipitations switch
            {
                PrecipitationType.None or
                PrecipitationType.Clouds or
                PrecipitationType.Drizzle or
                PrecipitationType.Mist or
                PrecipitationType.Smoke or
                PrecipitationType.Haze or
                PrecipitationType.Sand or
                PrecipitationType.Dust or
                PrecipitationType.Foggy => NoFlightReasons.None,
                _ => NoFlightReasons.ImportantPrecipitations
            });

            return reasons == NoFlightReasons.None
                ? new FlightDecision(FlightRecomendation.GoodForFlight, NoFlightReasons.None)
                : new FlightDecision(FlightRecomendation.BadForFlight, reasons);
        }

    }
}
