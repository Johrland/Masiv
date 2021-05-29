using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRoulette.Models
{
    public class Bet
    {
        public string betType { get; set; } 
        public string bet { get; set; }
        public int userId { get; set; }
        public double amount { get; set; }
        public int rouletteId { get; set; }
    }
}
