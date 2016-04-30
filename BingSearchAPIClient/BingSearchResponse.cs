using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSearchClient
{
    public class BingSearchResponse
    {
        public List<Value> Values { get; set; }
    }

    public class Value
    {
        public string ThumbnailUrl { get; set; }
    }
}
