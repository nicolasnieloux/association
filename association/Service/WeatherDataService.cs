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
            Display.DisplayWeatherData(weatherData);

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException capturée !");
            Console.WriteLine("Message : {0} ", e.Message);
        }
    }
}
}