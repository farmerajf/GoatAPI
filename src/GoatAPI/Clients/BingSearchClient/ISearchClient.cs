using System.Threading.Tasks;

namespace GoatAPI.Clients.BingSearchClient
{
    /// <summary>
    /// Models the Bing search API
    /// </summary>
    public interface ISearchClient
    {
        /// <summary>
        /// Make an async search of the Bing API, using the given query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<BingSearchResponse> SearchImagesAsync(string query);
    }
}
