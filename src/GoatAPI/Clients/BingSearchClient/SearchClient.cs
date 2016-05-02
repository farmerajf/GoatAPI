using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoatAPI.Clients.BingSearchClient
{
	/// <summary>
	/// Searches the Bing API.
	/// </summary>
	public class SearchClient : ISearchClient
	{
		private readonly string _apiKey;
		private readonly Uri _apiBaseUri = new Uri("https://bingapis.azure-api.net/api/v5/images/search");

		/// <summary>
		/// Initialize with the API key.
		/// </summary>
		/// <param name="apiKey">The API  key.</param>
		public SearchClient(string apiKey)
		{
			_apiKey = apiKey;
		}

		/// <summary>
		/// Makes a search request for a given query.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns></returns>
		public async Task<BingSearchResponse> SearchImagesAsync(string query)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = _apiBaseUri;
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);

				var uriToCall = new UriBuilder(_apiBaseUri)
				                {
					                Query = "q=" + query
				                };
				var response = await client.GetAsync(uriToCall.Uri);
				response.EnsureSuccessStatusCode();

				var json = await response.Content.ReadAsStringAsync();
				var bingSearchReponse = JsonConvert.DeserializeObject<BingSearchResponse>(json);
				return bingSearchReponse;
			}
		}
	}
}