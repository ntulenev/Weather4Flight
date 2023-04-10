namespace OpenWeatherMap.Serialization;

/// <summary>
/// Interface for a JSON serializer.
/// </summary>
public interface IJsonSerializer
{
    /// <summary>
    /// Deserializes JSON data into an object of type T.
    /// </summary>
    /// <typeparam name="T">The type of object to deserialize the JSON into.</typeparam>
    /// <param name="json">The JSON data to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    T Deserialize<T>(string json);
}
