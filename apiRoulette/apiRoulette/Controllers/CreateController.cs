using apiRoulette.Admin;
using apiRoulette.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
            List<Roulette> roulettes;
              try {roulettes = JsonConvert.DeserializeObject<List<Roulette>>(_cache.GetString("roulettes"));}
            catch { roulettes = null; }

            if (roulettes is null)
            {
                Roulette roulette = new adminRoulette().createRullete();
                roulettes = new List<Roulette>();
                roulettes.Add(roulette);
            }
            else { roulettes = new adminRoulette().createRullete(roulettes); }
            
            _cache.SetString("roulettes", JsonConvert.SerializeObject(roulettes, Formatting.Indented));

            return new JsonResult(roulettes.LastOrDefault().id);
        }
        

    }
}