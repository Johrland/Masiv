using apiRoulette.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace apiRoulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private IDistributedCache _cache;

        public CreateController(IDistributedCache cache)
        {
            this._cache = cache;
        }
        [HttpPost]
        public void Post(string command)
        {

        }
        [HttpGet]
        public JsonResult Roulette()
        {
            int test;
            bool success = Int32.TryParse(_cache.GetString("id"), out test);
                test = new adminRoulette().createRullete(test, success);
                _cache.SetString("id", test.ToString());
                return new JsonResult(test);
        }
        

    }
}