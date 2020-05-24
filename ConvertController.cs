using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace currency_api_by_n30_kl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        [HttpGet("/Convert/pair1={pair1}/pair2={pair2}/amount={amount}")]
        public string GetInfo(string pair1, string pair2, string amount)
        {
            var jo = JObject.Parse(Get.GetStr($"https://fcsapi.com/api-v2/forex/converter?pair1={pair1}&pair2={pair2}&amount={amount}&access_key=VJAtFQaCt1sAZmJrFpfC9gERzgZjonNqhuQeq5jkvlgukvNWHL"));

            return $"{amount} {pair1} это {jo["response"]["total"]} {pair2}.";
        }
    }
}