using System;
using System.Net.Http;
using System.Threading.Tasks;
using association.Api;

namespace association.Service
{
    public class WeatherDataService {
    public async Task dataTask()
    {
        IAPIClient apiClient = new APIClient();

        string apiUrl = "http://www.infoclimat.fr/public-api/gfs/json?_ll=48.85341,2.3488&_auth=VE4CFVIsBiRfclFmAnQBKFU9DzoKfAUiAHxSMVs%2BUi8BagRlAmJQNl8xB3pQf1BmVHkObVliCTlXPFAoXS8DYlQ%2BAm5SOQZhXzBRNAItASpVew9uCioFIgBiUjxbNVIvAWAEZAJpUCxfNQdtUH5QZVRgDmhZeQkuVzVQMF0yA2JUPgJlUjAGbV83UToCLQEqVWAPaQpnBTwAN1JnWzZSYwFmBGECaVAzX2EHbFB%2BUGRUZQ5vWWcJMVc3UDFdNQN%2FVCgCH1JCBnlfcFFxAmcBc1V7DzoKawVp&_c=4546c9308c888fb29c285274ce9c6563";

        try
        {
            string response = await apiClient.GetApiResponseAsync(apiUrl);
            Console.WriteLine(response);

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException capturée !");
            Console.WriteLine("Message : {0} ", e.Message);
        }

        // Attendre l'appui d'une touche pour fermer la console
        Console.ReadKey();
    }
}
}