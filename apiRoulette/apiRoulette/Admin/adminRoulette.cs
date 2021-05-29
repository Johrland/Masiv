using apiRoulette.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRoulette.Admin
{
    public class adminRoulette
    {
        public Roulette createRullete()
        {
            Roulette roulette = new Roulette
                {
                    id = 1,
                    status = "Close",
                    bets = new List<Bet>()
                };
            
            return roulette;
        }
        public List<Roulette> createRullete(List<Roulette> roulettes)
        { 
            roulettes.Add(new Roulette {
                    id = roulettes.LastOrDefault().id + 1,
                    status = "Close",
                    bets = new List<Bet>()
            });
            return roulettes;
        }

    }
}
