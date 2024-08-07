using System;
using System.Threading.Tasks;
using association.Service;

namespace associationConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WeatherDataService weatherDataService = new WeatherDataService();
            Console.Write("Veuillez saisir le lieu : ");
            string lieu = Console.ReadLine();
            await weatherDataService.dataTask(lieu);
        }
    }
}