using Abstractions;
using Logic;
using Models;
using OpenWeatherMap.Configuration;
using OpenWeatherMap.Configuration.Validation;
using OpenWeatherMap.Logic;
using OpenWeatherMap.Serialization;

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddSingleton<IOpenWeatherLoader, OpenWeatherLoader>();
builder.Services.AddSingleton<IForecastConverter, ForecastConverter>();
builder.Services.AddSingleton<IJsonSerializer, SystemTextJsonSerializer>();
builder.Services.Configure<OpenWeatherMapConfiguration>(builder.Configuration.GetSection("OpenWeatherMapConfiguration"));
builder.Services.AddSingleton<IValidateOptions<OpenWeatherMapConfiguration>, OpenWeatherMapConfigurationValidator>();
builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/weather/{cityName}",
            async (string cityName,
                   IWeatherForecastService weatherService,
                   CancellationToken cancellationToken) =>
{
    var city = new CityName(cityName);
    var forecast = await weatherService.LoadWeatherForecastAsync(city, cancellationToken);
    return forecast.WeatherConditions.Select(x =>
            new
            {
                Date = x.Key,
                Weather = x.Value,
                FlightDecisio = x.Value.CreateFlightDecision()
            });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
