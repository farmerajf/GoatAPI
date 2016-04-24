using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace GoatAPI.Controllers
{
    [Route("v1/quote")]
    public class QuoteController : Controller
    {
        // GET: api/values
        [HttpGet]
        public object Get()
        {
            var quotes = new List<string>
            {
                "Here we goat again",
                "You have goat to be kidding me",
                "Row, row, row, your goat",
                "Shit just goat serious",
                "Calm down, I goat this",
                "Whatever floats your goat",
                "Goat milk?"
            };

            var random = new Random().Next(quotes.Count);

            return new { id = random, value = quotes[random] };
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
