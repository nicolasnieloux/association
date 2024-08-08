using System;
using System.Collections.Generic;
using association.Model;

namespace association.Utils
{
    public class Display
    {
        public static string ConvertNebulositeToText(float nebulositeTotale)
        {
            if (nebulositeTotale <= 20)
            {
                return "Clair";
            }
            else if (nebulositeTotale <= 40)
            {
                return "Peu nuageux";
            }
            else if (nebulositeTotale <= 60)
            {
                return "Nuageux";
            }
            else if (nebulositeTotale <= 80)
            {
                return "Très nuageux";
            }
            else
            {
                return "Couvert";
            }
        }

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

                float nebTotaleTotal = entry.Value["nebulositeTotaleTotal"];
                string nebTotalText = ConvertNebulositeToText(nebTotaleTotal);
            
                Console.WriteLine($"Date : {datetime}");
                Console.WriteLine($"Nebulosite totale : {nebTotaleTotal} - {nebTotalText}");
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}