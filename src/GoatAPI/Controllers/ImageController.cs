using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingSearchClient;
using Microsoft.AspNet.Mvc;

namespace GoatAPI.Controllers
{
    /// <summary>
    /// Handles routes for images.
    /// </summary>
    [Route("v1/images")]
    public class ImageController : Controller
    {
        private readonly ISearchClient _searchClient;

        /// <summary>
        /// Initialises with the Bing search client.
        /// </summary>
        /// <param name="searchClient"></param>
        public ImageController(ISearchClient searchClient)
        {
            _searchClient = searchClient;
        }

        /// <summary>
        /// Returns a random image of a goat.
        /// </summary>
        /// <returns>The uri to a goat image.</returns>
        [Route("random")]
        [HttpGet]
        public async Task<IEnumerable<string>> GetRandomImage()
        {
            var searchResponse = await _searchClient.SearchImagesAsync("goat");
            var resultImages = searchResponse.GoatImages.ToList();
            var randomResultIndex = new Random().Next(resultImages.Count);
            var randomImage = new[] { "url", resultImages[randomResultIndex].ThumbnailUrl };

            return randomImage;
        }
    }
}
