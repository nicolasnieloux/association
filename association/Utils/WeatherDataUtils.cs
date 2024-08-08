using System.Collections.Generic;
using association.Model;

namespace association.Utils
{
    public static class WeatherDataUtils
    {
        public static void AccumulateWeatherData(WeatherDetails details, Dictionary<string, Dictionary<string, float>> dailyWeather, string date)
        {
            // Calculate daily data
            if (!dailyWeather.ContainsKey(date))
            {
                dailyWeather[date] = new Dictionary<string, float>
                {
                    { "t2mTotal", 0 },
                    { "pressureTotal", 0 },
                    { "rainfallTotal", 0 },
                    { "ventMoyenTotal", 0 },
                    { "ventRafalesTotal", 0 },
                    { "ventDirectionTotal", 0 },
                    { "nebulositeHauteTotal", 0 },
                    { "nebulositeMoyenneTotal", 0 },
                    { "nebulositeBasseTotal", 0 },
                    { "nebulositeTotaleTotal", 0 },                    
                    { "hours", 0 }
                };
            }

            // Add measures to the corresponding date
            dailyWeather[date]["t2mTotal"] += details.Temperature.T2m;
            dailyWeather[date]["pressureTotal"] += details.Pression.NiveauDeLaMer;
            dailyWeather[date]["rainfallTotal"] += details.PluieConvective;
            dailyWeather[date]["ventMoyenTotal"] += details.VentMoyen.V10m;
            dailyWeather[date]["ventRafalesTotal"] += details.VentRafales.V10m;
            dailyWeather[date]["ventDirectionTotal"] += details.VentDirection.V10m;
            dailyWeather[date]["nebulositeHauteTotal"] += details.Nebulosite.Haute;
            dailyWeather[date]["nebulositeMoyenneTotal"] += details.Nebulosite.Moyenne;
            dailyWeather[date]["nebulositeBasseTotal"] += details.Nebulosite.Basse;
            dailyWeather[date]["nebulositeTotaleTotal"] += details.Nebulosite.Totale;           
            dailyWeather[date]["hours"] += 1;
        }

        public static void CalculateAverageWeatherData(Dictionary<string, Dictionary<string, float>> dailyWeather)
        {
            // For each day, divide total measurements by number of hours to get the averages
            foreach (var dailyEntry in dailyWeather)
            {
                float hours = dailyEntry.Value["hours"];
                dailyEntry.Value["t2mTotal"] /= hours;
                dailyEntry.Value["pressureTotal"] /= hours;
                dailyEntry.Value["rainfallTotal"] /= hours;
                dailyEntry.Value["ventMoyenTotal"] /= hours;
                dailyEntry.Value["ventRafalesTotal"] /= hours;
                dailyEntry.Value["ventDirectionTotal"] /= hours;
                dailyEntry.Value["nebulositeHauteTotal"] /= hours;
                dailyEntry.Value["nebulositeMoyenneTotal"] /= hours;
                dailyEntry.Value["nebulositeBasseTotal"] /= hours;
                dailyEntry.Value["nebulositeTotaleTotal"] /= hours;               
            }
        }
    }
}