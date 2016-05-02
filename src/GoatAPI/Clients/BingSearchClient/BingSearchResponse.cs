using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoatAPI.Clients.BingSearchClient
{
    /// <summary>
    /// Models the deserialized response from a Bing search.
    /// </summary>
    public class BingSearchResponse
    {
        /// <summary>
        /// The search results.
        /// </summary>
        [JsonProperty("Value")]
        public IEnumerable<GoatImage> GoatImages { get; set; }
    }
}