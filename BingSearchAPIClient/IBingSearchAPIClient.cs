using System.Threading.Tasks;

namespace BingSearchClient
{
    public interface IBingSearchAPIClient
    {
        Task<BingSearchResponse> SearchImagesAsync(string query);
    }
}
