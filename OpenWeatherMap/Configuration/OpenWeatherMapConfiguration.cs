namespace OpenWeatherMap.Configuration
{
    /// <summary>
    /// Represents the configuration settings for the OpenWeatherMap API.
    /// </summary>
    public class OpenWeatherMapConfiguration
    {
        /// <summary>
        /// Gets or sets the API key for accessing the OpenWeatherMap API.
        /// </summary>
        /// <remarks>
        /// This property is required and must be set to a valid API key in order to use the OpenWeatherMap API.
        /// </remarks>
        public string ApiKey { get; init; } = default!;

        /// <summary>
        /// API template for get data from OpenWeatherMap API.
        /// </summary>
        public string ApiUrl { get; init; } = default!;
    }

}
