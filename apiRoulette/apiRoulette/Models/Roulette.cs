using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRoulette.Models
{
    public class Roulette
    {
        public int id { get; set; }
        public string status { get; set; }
        public List<Bet> bets { get; set; }
    }
}
