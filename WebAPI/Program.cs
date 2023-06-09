using Abstractions;
using Logic;
using Models;
using OpenWeatherMap.Configuration;
using OpenWeatherMap.Configuration.Validation;
using OpenWeatherMap.Logic;
using OpenWeatherMap.Serialization;
using WebAPI.DTO;

using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http.Json;

using System.Text.Json.Serialization;

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
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.MapGet("/weather/{cityName}",
            async (string cityName,
                   IWeatherForecastService weatherService,
                   CancellationToken cancellationToken) =>
{
    var city = new CityName(cityName);
    var forecast = await weatherService.LoadWeatherForecastAsync(city, cancellationToken);
    return FlightForecast.CreateFromModel(forecast);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

/// <summary>
/// Need for correct work of IClassFixture<WebApplicationFactory<Program>> in WebAPI.Tests 
/// </summary>
public partial class Program { }