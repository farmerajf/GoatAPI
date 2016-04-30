using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BingSearchClient
{
    public class BingSearchAPIClient
    {
        private readonly string _apiKey;
        private const string ApiBaseUri = "https://bingapis.azure-api.net/api/v5/images/search";

        public BingSearchAPIClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<BingSearchResponse> SearchImagesAsync(string query)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);

                var response = await client.GetAsync(ApiBaseUri + "?q=" + query);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var bingSearchReponse = JsonConvert.DeserializeObject<BingSearchResponse>(json);
                return bingSearchReponse;
            }
        }
    }
}
