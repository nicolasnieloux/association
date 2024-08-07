using System.Threading.Tasks;
using association.Service;

namespace associationConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WeatherDataService weatherDataService = new WeatherDataService();
            await weatherDataService.dataTask();       }
        }
    }
