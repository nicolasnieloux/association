using System;
using System.Collections.Generic;
using association.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace association.Utils
{
    public class Display
    {
        public static void DisplayWeatherData(WeatherData weatherData)
        {
            foreach(KeyValuePair<string, JToken> entry in weatherData.data)
            {
                string datetime = entry.Key;
                WeatherDetails details = JsonConvert.DeserializeObject<WeatherDetails>(entry.Value.ToString());

                Console.WriteLine($"Date et heure: {datetime}");
                Console.WriteLine($"Température à 2 mètres : {details.Temperature.T2m}");
                Console.WriteLine($"Pression au niveau de la mer : {details.Pression.NiveauDeLaMer}");
                Console.WriteLine($"Pluie (convective) : {details.PluieConvective}");
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}