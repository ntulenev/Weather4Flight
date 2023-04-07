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

        public FlightDecision CreateFlightDecision()
        {
            throw new NotImplementedException();
        }
    }
}
