using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace currency_api_by_n30_kl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        [HttpGet("/Period/symbol={symbol}/from={from}/to={to}")]
        public string GetInfo(string symbol, string from, string to)
        {
            JObject googleSearch = JObject.Parse(Get.GetStr($"https://fcsapi.com/api-v2/forex/history?symbol={symbol}/UAH&from={from}&to={to}&access_key=VJAtFQaCt1sAZmJrFpfC9gERzgZjonNqhuQeq5jkvlgukvNWHL"));

            IList<JToken> results = googleSearch["response"].Children().ToList();

            string response = null;

            List<string> dates = new List<string>();

            foreach (JToken result in results)
            {
                SearchResultFX searchResult = result.ToObject<SearchResultFX>();

                if (!dates.Contains(searchResult.tm.Split(' ')[0]))
                {
                    dates.Add(searchResult.tm.Split(' ')[0]);

                    response += $"Дата: {searchResult.tm.Split(' ')[0]};\nЦена: {searchResult.c}грн.\n";
                }
            }
            return response;
            ;
        }
    }
    public class SearchResultFX
    {
        public decimal c { get; set; }
        public string tm { get; set; }
    }

}