using System;
using System.Collections.Generic;
using System.Linq;
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
            var resultImages = result.Value.ToList();
            var randomResultIndex = new Random().Next(resultImages.Count());
            return new[] { "url", resultImages[randomResultIndex].ThumbnailUrl };
        }
    }
}
