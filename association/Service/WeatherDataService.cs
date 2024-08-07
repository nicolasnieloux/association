using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using association.Api;
using association.Model;
using association.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace association.Service
{
    public class WeatherDataService {
    public async Task dataTask(string address)
{
    GeocodingService geocodingService = new GeocodingService();
    
    Tuple<double, double> latLong = await geocodingService.GetLatLongFromAddress(address);
    string latLongString = $"_ll={latLong.Item1.ToString(CultureInfo.InvariantCulture)},{latLong.Item2.ToString(CultureInfo.InvariantCulture)}";
    Console.WriteLine(latLongString);
    IAPIClient apiClient = new APIClient();
    
    string apiUrl = $"{Constants.BaseUrl}{latLongString}&{Constants.Auth}&{Constants.End}";   
    
    try
    {
        string response = await apiClient.GetApiResponseAsync(apiUrl);
        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
        Dictionary<string, Dictionary<string, float>> dailyWeather = new Dictionary<string, Dictionary<string, float>>();
        
        foreach (var entry in weatherData.data)
        {
            // Convertir le timestamp (la clé) à un object DateTime.
            DateTime timestamp = DateTime.ParseExact(entry.Key, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string date = timestamp.ToString("yyyy-MM-dd");

            // Désérialiser les détails météo (la valeur) vers WeatherDetails.
            WeatherDetails details = entry.Value.ToObject<WeatherDetails>();

            // Compute daily average
            if (!dailyWeather.ContainsKey(date))
            {
                dailyWeather[date] = new Dictionary<string, float>
                {
                    { "t2mTotal", 0 },
                    { "pressureTotal", 0 },
                    { "rainfallTotal", 0 },
                    { "hours", 0 }
                };
            }

            // Ajoutez les mesures à la date correspondante.
            dailyWeather[date]["t2mTotal"] += details.Temperature.T2m;
            dailyWeather[date]["pressureTotal"] += details.Pression.NiveauDeLaMer;
            dailyWeather[date]["rainfallTotal"] += details.PluieConvective;
            dailyWeather[date]["hours"] += 1;
        }
    
        Display.DisplayDailyWeatherData(dailyWeather); // change this line
    
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException capturée !");
        Console.WriteLine("Message : {0} ", e.Message);
    }
}
}
}