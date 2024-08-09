using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using association.Api;
using association.Model;
using association.Utils;
using Newtonsoft.Json;

namespace association.Service
{
    public class WeatherDataService
    {
        public async Task DisplayWeatherData(string address)
        {
            var dailyWeather = await GetWeatherDataForEvent(address);
            Display.DisplayDailyWeatherData(dailyWeather);
        }

        public async Task<Dictionary<string, Dictionary<string, float>>> GetWeatherDataForEvent(string address)
        {
            GeocodingService geocodingService = new GeocodingService();

            Tuple<double, double> latLong = await geocodingService.GetLatLongFromAddress(address);
            string latLongString = $"_ll={latLong.Item1.ToString(CultureInfo.InvariantCulture)},{latLong.Item2.ToString(CultureInfo.InvariantCulture)}";
            IAPIClient apiClient = new APIClient();

            string apiUrl = $"{Constants.BaseUrl}{latLongString}&{Constants.Auth}&{Constants.End}";

            Dictionary<string, Dictionary<string, float>> dailyWeather =
                new Dictionary<string, Dictionary<string, float>>();
            
            try
            {
                string response = await apiClient.GetApiResponseAsync(apiUrl);
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
                foreach (var entry in weatherData.data)
                {
                    // Convertir le timestamp (la clé) à un object DateTime.
                    DateTime timestamp =
                        DateTime.ParseExact(entry.Key, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    string date = timestamp.ToString("yyyy-MM-dd");

                    // Désérialiser les détails météo (la valeur) vers WeatherDetails.
                    WeatherDetails details = entry.Value.ToObject<WeatherDetails>();

                    // Compute daily average
                    WeatherDataUtils.AccumulateWeatherData(details, dailyWeather, date);
                }

                WeatherDataUtils.CalculateAverageWeatherData(dailyWeather);
                Display.DisplayDailyWeatherData(dailyWeather);
                return dailyWeather;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException capturée !");
                Console.WriteLine("Message : {0} ", e.Message);
                return null;
            }
        }
    }
}