using Newtonsoft.Json;

namespace GoatAPI.Clients.BingSearchClient
{
    /// <summary>
	/// A GoatAPI Bing search result.
	/// </summary>
	[JsonObject("Value")]
	public class GoatImage
	{
		/// <summary>
		/// The thumbnail url.
		/// </summary>
		public string ThumbnailUrl { get; set; }
	}
}