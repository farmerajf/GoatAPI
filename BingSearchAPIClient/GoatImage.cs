namespace BingSearchClient
{
	using Newtonsoft.Json;

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