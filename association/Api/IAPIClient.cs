using System.Threading.Tasks;

namespace association.Api
{
    public interface IAPIClient
    {
        Task<string> GetApiResponseAsync(string url);
    }
}