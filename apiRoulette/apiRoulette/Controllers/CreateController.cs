using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiRoulette.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace apiRoulette.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        [HttpPost]
        public void Post(string command)
        {

        }
        [HttpGet]
        public JsonResult MostrarUltimaFactura(int id)
        {   if(!_cache.TryGetValue(id, out int idRoullete))
            {
                id = new Roulette().Create();
            }


        }
        return new JsonResult();

    }
}