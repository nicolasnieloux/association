using System;
using System.Threading.Tasks;
using association.Api;
using association.Utils;
using Newtonsoft.Json;

namespace association.Service
{
    public class GeocodingService
    {
        public async Task<Tuple<double, double>> GetLatLongFromAddress(string address)
        {
            var apiUrl = $"https://api.opencagedata.com/geocode/v1/json?q={Uri.EscapeDataString(address)}&key={Constants.apiKey}";
            IAPIClient apiClient = new APIClient();

            string response = await apiClient.GetApiResponseAsync(apiUrl);

            var parsedResponse = JsonConvert.DeserializeObject<dynamic>(response);
            var location = parsedResponse.results[0].geometry;
            var lat = (double)location.lat;
            var lng = (double)location.lng;

            return new Tuple<double, double>(lat, lng);
        }
    }
}