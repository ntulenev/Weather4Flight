using System.Text.Json;

namespace OpenWeatherMap.Serialization;

public class SystemTextJsonSerializer : IJsonSerializer
{
    public T Deserialize<T>(string json)
    {
        ArgumentNullException.ThrowIfNull(json);
        ArgumentException.ThrowIfNullOrEmpty(json);

        return JsonSerializer.Deserialize<T>(json)!;
    }
}
