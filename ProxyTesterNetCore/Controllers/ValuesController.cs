using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using ProxyTesterNetCore.Factories;

namespace ProxyTesterNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly HttpProxyClientFactory httpClientFactory;

        public ValuesController(HttpProxyClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            HttpClient client = httpClientFactory.Create();

            var response = client.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
            
            return Ok(response.Result);
        }
    }
}
