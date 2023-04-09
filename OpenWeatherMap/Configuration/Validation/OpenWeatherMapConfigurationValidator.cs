using Microsoft.Extensions.Options;

namespace OpenWeatherMap.Configuration.Validation;

/// <summary>
/// Validates the <see cref="OpenWeatherMapConfiguration"/> options.
/// </summary>
public class OpenWeatherMapConfigurationValidator : IValidateOptions<OpenWeatherMapConfiguration>
{
    /// <summary>
    /// Validates the specified <paramref name="options"/> object and returns a <see cref="ValidateOptionsResult"/> indicating success or failure.
    /// </summary>
    /// <param name="name">The name of the options being validated, or <c>null</c> if not applicable.</param>
    /// <param name="options">The <see cref="OpenWeatherMapConfiguration"/> options to validate.</param>
    /// <returns>A <see cref="ValidateOptionsResult"/> indicating whether validation succeeded or failed, and an optional error message if applicable.</returns>
    public ValidateOptionsResult Validate(string? name, OpenWeatherMapConfiguration options)
    {
        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            return ValidateOptionsResult.Fail("API key is required.");
        }

        return ValidateOptionsResult.Success;
    }
}


