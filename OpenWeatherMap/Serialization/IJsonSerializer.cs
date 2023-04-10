namespace OpenWeatherMap.Serialization;

public interface IJsonSerializer
{
    T Deserialize<T>(string json);
}
