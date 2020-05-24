using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace currency_api_by_n30_kl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BydayController : ControllerBase
    {
        [HttpGet("/Byday/date={date}")]
        public string GetInfo(string date)
        {
            JObject googleSearch = JObject.Parse(Get.GetStr($"https://api.privatbank.ua/p24api/exchange_rates?json&date={date}"));

            IList<JToken> results = googleSearch["exchangeRate"].Children().ToList();

            string response = null;

            foreach (JToken result in results)
            {
                SearchResultPB searchResult = result.ToObject<SearchResultPB>();

                if (searchResult.currency == "EUR" || searchResult.currency == "USD" || searchResult.currency == "RUB")

                    response += $"Валюта: {searchResult.currency}\nКурс продажи: {searchResult.saleRate}грн.\nКурс покупки: {searchResult.purchaseRate}грн.\n";
            }
            return response;
        }
    }
        public class SearchResultPB
        {
            public string currency { get; set; }
            public string saleRate { get; set; }
            public string purchaseRate { get; set; }
        }

    }