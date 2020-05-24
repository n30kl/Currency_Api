using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace currency_api_by_n30_kl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CinfoController : ControllerBase
    {
        [HttpGet("/Cinfo/symbol={symbol}")]
        public string GetInfo(string symbol)
        {
            JObject googleSearch = JObject.Parse(Get.GetStr($"https://fcsapi.com/api-v2/forex/profile?symbol={symbol}&access_key=VJAtFQaCt1sAZmJrFpfC9gERzgZjonNqhuQeq5jkvlgukvNWHL"));

            IList<JToken> results = googleSearch["response"].Children().ToList();

            foreach (JToken result in results)
            {
                SearchInfoFX searchResult = result.ToObject<SearchInfoFX>();

                return $"Короткое название: {searchResult.short_name};\nНазвание: {searchResult.name};\nСтрана: {searchResult.country};\nСимвол: {searchResult.symbol}.";

            }
            return "";
        }
    }
        public class SearchInfoFX
        {
            public string short_name { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public string symbol { get; set; }
        }

    }