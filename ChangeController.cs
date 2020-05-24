using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace currency_api_by_n30_kl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        [HttpGet("/Change/symbol={symbol}")]
        public string GetInfo(string symbol)
        {

            JObject googleSearch = JObject.Parse(Get.GetStr($"https://fcsapi.com/api-v2/forex/latest?symbol={symbol}/UAH&access_key=VJAtFQaCt1sAZmJrFpfC9gERzgZjonNqhuQeq5jkvlgukvNWHL"));

            IList<JToken> results = googleSearch["response"].Children().ToList();

            foreach (var result in results)
            {
                Searchbyname searchResult = result.ToObject<Searchbyname>();
                 
                return $"Валюта: {symbol};\nЦена: {searchResult.price}грн.;\nИзмененилась на: {searchResult.change}грн. ({searchResult.chg_per});\nПоследние изменения: {searchResult.last_changed}.";
            }
            return "";
        }
        public class Searchbyname
        {
            public decimal price { get; set; }
            public string change { get; set; }
            public string chg_per { get; set; }
            public string last_changed { get; set; }
        }

    }
}