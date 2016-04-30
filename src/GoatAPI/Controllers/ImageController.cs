using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BingSearchClient;
using Microsoft.AspNet.Mvc;

namespace GoatAPI.Controllers
{
    [Route("v1/randomimage")]
    public class ImageController : Controller
    {
        private readonly IBingSearchAPIClient _bingSearchApiClient;

        public ImageController(IBingSearchAPIClient bingSearchApiClient)
        {
            _bingSearchApiClient = bingSearchApiClient;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var result = await _bingSearchApiClient.SearchImagesAsync("goat");
            var randomResultIndex = new Random().Next(result.Value.Count);
            return new[] { "url", result.Value[randomResultIndex].ThumbnailUrl };
        }
    }
}
