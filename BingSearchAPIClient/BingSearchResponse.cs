using System.Collections.Generic;

namespace BingSearchClient
{
    public class BingSearchResponse
    {
        public List<Value> Value { get; set; }
    }

    public class Value
    {
        public string ThumbnailUrl { get; set; }
    }
}
