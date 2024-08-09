using System.Net.Http;
using System.Threading.Tasks;

namespace association.Api
{
    public class APIClient : IAPIClient
    {
        private readonly HttpClient _httpClient;

        public APIClient()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<string> GetApiResponseAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }
    }
}