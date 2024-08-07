using System;
using System.Collections.Generic;
using association.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace association.Utils
{
    public class Display
    {
        public static void DisplayDailyWeatherData(Dictionary<string, Dictionary<string, float>> dailyWeather)
        {
            if (dailyWeather.Count == 0)
            {
                Console.WriteLine("Pas de données météo disponibles.");
                return;
            }

            foreach (var entry in dailyWeather)
            {
                string datetime = entry.Key;
                // Convertir de Kelvin à Celsius.
                float t2m = entry.Value["t2mTotal"] / entry.Value["hours"] - 273.15f;
                float pressure = entry.Value["pressureTotal"] / entry.Value["hours"];
                float rainfall = entry.Value["rainfallTotal"] / entry.Value["hours"];
        
                Console.WriteLine($"Date : {datetime}");
                Console.WriteLine($"Moyenne de température : {t2m:F2} °C");
                Console.WriteLine($"Moyenne de pression au niveau de la mer : {pressure:F2} hPa");
                Console.WriteLine($"Moyenne de pluie convective : {rainfall:F2} mm");
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}