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

```yaml
[
   {
      "date":"2023-04-15T09:00:00+00:00",
      "weather":{
         "temperature":{
            "value":15.58,
            "category":"Normal"
         },
         "windSpeed":{
            "value":7.09,
            "isStrongWind":false
         },
         "precipitations":"Clouds"
      },
      "flightDecisio":{
         "recomendation":"GoodForFlight",
         "reasons":"None"
      }
   },
   {
      "date":"2023-04-15T12:00:00+00:00",
      "weather":{
         "temperature":{
            "value":15.98,
            "category":"Normal"
         },
         "windSpeed":{
            "value":8.53,
            "isStrongWind":false
         },
         "precipitations":"Clouds"
      },
      "flightDecisio":{
         "recomendation":"GoodForFlight",
         "reasons":"None"
      }
   },
   {
      "date":"2023-04-15T15:00:00+00:00",
      "weather":{
         "temperature":{
            "value":16.36,
            "category":"Normal"
         },
         "windSpeed":{
            "value":9.14,
            "isStrongWind":false
         },
         "precipitations":"Clouds"
      },
      "flightDecisio":{
         "recomendation":"GoodForFlight",
         "reasons":"None"
      }
   },
   {
      "date":"2023-04-15T18:00:00+00:00",
      "weather":{
         "temperature":{
            "value":15.57,
            "category":"Normal"
         },
         "windSpeed":{
            "value":6.13,
            "isStrongWind":false
         },
         "precipitations":"Clouds"
      },
      "flightDecisio":{
         "recomendation":"GoodForFlight",
         "reasons":"None"
      }
   },
   {
      "date":"2023-04-15T21:00:00+00:00",
      "weather":{
         "temperature":{
            "value":15.69,
            "category":"Normal"
         },
         "windSpeed":{
            "value":5.6,
            "isStrongWind":false
         },
         "precipitations":"Clouds"
      },
      "flightDecisio":{
         "recomendation":"GoodForFlight",
         "reasons":"None"
      }
   },
   {
      "date":"2023-04-16T00:00:00+00:00",
      "weather":{
         "temperature":{
            "value":15.65,
            "category":"Normal"
         },
         "windSpeed":{
            "value":4.76,
            "isStrongWind":false
         },
         "precipitations":"Clouds"
      },
      "flightDecisio":{
         "recomendation":"GoodForFlight",
         "reasons":"None"
      }
   },
   ...
]
```

Each object in the array represents a weather forecast for a specific time slot. It includes the date and time of the forecast, as well as the weather information such as temperature, wind speed, and precipitation. It also includes a flightDecision object that provides a drone flight recommendation and the reasons for it.

## Conclusion

We plan to expand and improve the functionality of this API in the future to provide even more accurate recommendations for drone flight.