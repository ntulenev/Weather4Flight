namespace Models
{
    /// <summary>
    /// Represents the reasons why a flight may not be recommended.
    /// </summary>
    [Flags]
    public enum NoFlightReasons
    {
        /// <summary>
        /// No reason for not recommending a flight.
        /// </summary>
        None = 0,

        /// <summary>
        /// The temperature is too cold for flying.
        /// </summary>
        ColdTemperature,

        /// <summary>
        /// The temperature is too hot for flying.
        /// </summary>
        HotTemperature,

        /// <summary>
        /// The wind speed is too high for flying.
        /// </summary>
        Wind,

        /// <summary>
        /// Precipitations that could affect flight.
        /// </summary>
        ImportantPrecipitations
    }

}
