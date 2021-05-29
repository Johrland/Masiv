using apiRoulette.Admin;
using apiRoulette.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiRoulette.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IDistributedCache _cache;

        public AdminController(IDistributedCache cache)
        {
            _cache = cache;
        }
        [HttpGet]
        public JsonResult index()
        {
            List<Roulette> roulettes;
            try
            {
                roulettes = JsonConvert.DeserializeObject<List<Roulette>>(_cache.GetString("roulettes"));
                return new JsonResult(roulettes);
            }
            catch (Exception ex)
            {
                return new JsonResult("Error: " + ex.ToString());
            }
        }
        [HttpGet]
        public JsonResult OpenRoulette(int id)
        {
            List<Roulette> roulettes;
            try { roulettes = JsonConvert.DeserializeObject<List<Roulette>>(_cache.GetString("roulettes"));

                adminRoulette admin = new adminRoulette();
                Roulette roulette = admin.searchRoulette(roulettes,id);
                if (roulette != null && roulette.status.Equals("Close"))
                {
                    admin.openRoulette(roulettes, roulette);
                    _cache.SetString("roulettes", JsonConvert.SerializeObject(roulettes, Formatting.Indented));
                    return new JsonResult("OK");
                }
                else { return new JsonResult("Error: Rouleta no Existe o ya se encuentra abierta"); }
            }
            catch(Exception ex)
            {
                return new JsonResult("Error: " + ex.ToString());
            }
        }
        [HttpGet]
        public JsonResult CreateRoulette()
        {
            List<Roulette> roulettes;
              try {roulettes = JsonConvert.DeserializeObject<List<Roulette>>(_cache.GetString("roulettes"));}
            catch { roulettes = null; }

            if (roulettes is null)
            {
                Roulette roulette = new adminRoulette().createRoulette();
                roulettes = new List<Roulette>
                {
                    roulette
                };
            }
            else { roulettes = new adminRoulette().createRoulette(roulettes); }
            
            _cache.SetString("roulettes", JsonConvert.SerializeObject(roulettes, Formatting.Indented));

            return new JsonResult(roulettes.LastOrDefault().id);
        }
        [HttpPost]
        public JsonResult BidBet([FromHeader] int userId,Bet bet)
        {
            List<Roulette> roulettes;
            try { roulettes = JsonConvert.DeserializeObject<List<Roulette>>(_cache.GetString("roulettes"));
                adminRoulette admin = new adminRoulette();
                bool check = admin.checkBet(bet);
                if (check)
                {
                    bet.userId = userId;
                    Roulette roulette = admin.searchRoulette(roulettes, bet.rouletteId);
                    if (roulette != null)
                    { 
                        admin.makeBet(roulettes, roulette, bet);
                        _cache.SetString("roulettes", JsonConvert.SerializeObject(roulettes, Formatting.Indented));
                        return new JsonResult("OK");
                    } else { return new JsonResult("Error: Rouleta no Existe"); }
                } 
                else { return new JsonResult("Error : Revisar datos de Apuesta, Data : " + bet.ToString());}
            }
            catch (Exception ex) { return new JsonResult("Error: " + ex.ToString()); }
            
        }
        [HttpGet]
        public JsonResult CloseRoulette(int id)
        {
            List<Roulette> roulettes;
            try
            {
                roulettes = JsonConvert.DeserializeObject<List<Roulette>>(_cache.GetString("roulettes"));

                adminRoulette admin = new adminRoulette();
                Roulette roulette = admin.searchRoulette(roulettes, id);
                if (roulette != null && roulette.status.Equals("Open"))
                {
                    admin.closeRoulette(roulettes, roulette);
                    _cache.SetString("roulettes", JsonConvert.SerializeObject(roulettes, Formatting.Indented));
                    List<Bet> betsWinners = admin.getBetsWinners(roulette.bets);
                    List<Winner> winners = admin.computeWinners(betsWinners);
                    _cache.SetString("winners", JsonConvert.SerializeObject(winners, Formatting.Indented));
                    return new JsonResult(winners);
                }
                else { return new JsonResult("Error: Rouleta no Existe o ya se encuentra cerrada."); }
            }
            catch (Exception ex)
            {
                return new JsonResult("Error: " + ex.ToString());
            }

        }
    }
}