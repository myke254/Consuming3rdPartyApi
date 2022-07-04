using Consuming3rdPartyApi.models;
using Microsoft.AspNetCore.Mvc;
using MobileMoney.Business.Utils;
using Newtonsoft.Json;

namespace Consuming3rdPartyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumeApiController : ControllerBase
    {
       
        private string url = "https://api-omnichannel-dev.azure-api.net/v1/datalookup/telcos";
        private HttpClientUtil _util;
       HttpClient client = new HttpClient();
        public ConsumeApiController(HttpClientUtil util)
        {
            this._util = util;
        }

        [HttpGet]
        public async Task<IActionResult> FetchData()
        {
            List<Telco>? cs = new List<Telco>();
            HttpResponseMessage res = await client.GetAsync(this.url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                cs = JsonConvert.DeserializeObject<List<Telco>>(result);

                return Ok(cs!);
            }
   
                return BadRequest();
            
        }

     /*   [HttpGet("getTelcos")]
        public IActionResult GetTelcos()
        {
            var telcos = _util.GetJSON<List<Telco>>(url);
            return Ok(telcos);
        }*/
    }
}
