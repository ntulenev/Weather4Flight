# Weather4Flight

This API provides weather forecasts and drone flight recommendations for a given city. It retrieves weather information from OpenWeatherMap and analyzes it to determine if it's safe to fly drones.

## Getting started

To get started with this API, you need to add your OpenWeatherMap API key to the configuration file. You can find the appsettings.json file in the root directory of the project. In this file, you will find the OpenWeatherMapConfiguration section. Add your API key to the ApiKey field as shown below.

```yaml
"OpenWeatherMapConfiguration": {
    "ApiKey": "YOUR_API_KEY_HERE",
    "ApiUrl": "https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric"
}
```

## Usage

To get weather forecasts for a city, you need to make an HTTP GET request to the following endpoint:

```yaml
/weather/{cityName}
```

For example:

```yaml
https://localhost:7085/weather/valletta
```

This will return an array of weather forecast objects with drone flight recommendations for each time slot.


| Property | Data Type | Description |
| --- | --- | --- |
| date | string | The date and time of the forecast in ISO 8601 format |
| recommendation | string | A recommendation for flying based on the weather conditions. Possible values: "GoodForFlight" or "BadForFlight" |
| reasons | string | The reasons for the recommendation. Possible values: "ImportantPrecipitations" if there is significant precipitation expected, or "None" if there are no significant weather conditions that would impact flying |
| precipitations | string | The type of precipitation expected, if any. Possible values: "Rain", "Snow", "Hail", "Sleet", "Drizzle", "Mist", "Fog", "Smoke", "Haze", "Dust", "Sand", "Ash", "Squall", "Tornado", "Clear", or "Clouds" |
| temperature | number | The temperature in degrees Celsius |
| windSpeed | number | The wind speed in meters per second |


```yaml
{
  "data": [
    {
      "date": "2023-04-16T09:00:00+00:00",
      "recomendation": "BadForFlight",
      "reasons": "ImportantPrecipitations",
      "precipitations": "Rain",
      "temperature": 12.64,
      "windSpeed": 6.44
    },
    {
      "date": "2023-04-16T12:00:00+00:00",
      "recomendation": "BadForFlight",
      "reasons": "ImportantPrecipitations",
      "precipitations": "Rain",
      "temperature": 13.99,
      "windSpeed": 9.9
    },
    {
      "date": "2023-04-16T15:00:00+00:00",
      "recomendation": "GoodForFlight",
      "reasons": "None",
      "precipitations": "Clouds",
      "temperature": 14.91,
      "windSpeed": 10.34
    },
    {
      "date": "2023-04-16T18:00:00+00:00",
      "recomendation": "GoodForFlight",
      "reasons": "None",
      "precipitations": "None",
      "temperature": 14.39,
      "windSpeed": 12.35
    },
    {
      "date": "2023-04-16T21:00:00+00:00",
      "recomendation": "GoodForFlight",
      "reasons": "None",
      "precipitations": "None",
      "temperature": 14.29,
      "windSpeed": 11.95
    },
    ...
  ]
}
```

Each object in the array represents a weather forecast for a specific time slot. It includes the date and time of the forecast, as well as the weather information such as temperature, wind speed, and precipitation. It also includes a flight decision that provides a drone flight recommendation and the reasons for it.

## Conclusion

We plan to expand and improve the functionality of this API in the future to provide even more accurate recommendations for drone flight.