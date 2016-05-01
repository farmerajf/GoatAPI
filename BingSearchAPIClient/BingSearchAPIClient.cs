using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BingSearchClient
{
    public class BingSearchAPIClient : IBingSearchAPIClient
    {
        private readonly string _apiKey;
        private readonly Uri _apiBaseUri = new Uri("https://bingapis.azure-api.net/api/v5/images/search");

        public BingSearchAPIClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<BingSearchResponse> SearchImagesAsync(string query)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress =_apiBaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);

                var uriToCall = new UriBuilder(_apiBaseUri) {Query = "q=" + query};
                var response = await client.GetAsync(uriToCall.Uri);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var bingSearchReponse = JsonConvert.DeserializeObject<BingSearchResponse>(json);
                return bingSearchReponse;
            }
        }
    }
}
