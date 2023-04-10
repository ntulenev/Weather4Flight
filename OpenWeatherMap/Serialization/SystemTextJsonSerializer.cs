using System.Text.Json;

namespace OpenWeatherMap.Serialization;

/// <summary>
/// Implementation of the <see cref="IJsonSerializer"/> interface using System.Text.Json.
/// </summary>
public class SystemTextJsonSerializer : IJsonSerializer
{
    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown when the json parameter is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the json parameter is empty or whitespace.</exception>
    public T Deserialize<T>(string json)
    {
        ArgumentNullException.ThrowIfNull(json);
        ArgumentException.ThrowIfNullOrEmpty(json);

        if (string.IsNullOrWhiteSpace(json))
        {
            throw new ArgumentException("Json string can't be whitespace");
        }

        return JsonSerializer.Deserialize<T>(json)!;
    }
}
