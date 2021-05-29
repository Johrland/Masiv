using apiRoulette.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRoulette.Admin
{
    public class adminRoulette
    {
        public Roulette createRoulette()
        {
            Roulette roulette = new Roulette
                {
                    id = 1,
                    status = "Close",
                    bets = new List<Bet>()
                };
            
            return roulette;
        }
        public List<Roulette> createRoulette(List<Roulette> roulettes)
        {
            roulettes = roulettes.OrderBy(r => r.id).ToList();
            roulettes.Add(new Roulette {
                    id = roulettes.LastOrDefault().id + 1,
                    status = "Close",
                    bets = new List<Bet>()
            });

            return roulettes;
        } 
        public List<Roulette> openRoulette(List<Roulette> roulettes, Roulette roulette)
        {
            try
            {
                roulettes.Remove(roulette);
                roulette.status = "Open";
                roulette.bets = new List<Bet>();
                roulettes.Add(roulette);
                return roulettes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Roulette> closeRoulette(List<Roulette> roulettes, Roulette roulette)
        {
            try
            {
                roulettes.Remove(roulette);
                roulette.status = "Close";
                roulettes.Add(roulette);

                return roulettes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Roulette> makeBet(List<Roulette> roulettes, Roulette roulette, Bet bet)
        {
            try
            {   roulettes.Remove(roulette);
                roulette.bets.Add(bet);
                roulettes.Add(roulette);

                return roulettes;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public bool checkBet(Bet bet)
        {
            bool check = false;
            if (bet.amount >= 0 && bet.amount <= 10000)
            {
                if (bet.betType.Equals("Color"))
                {
                    if (bet.bet.Equals("Rojo") || bet.bet.Equals("Negro"))
                    {
                        check = true;
                    }
                    else { check = false; }
                }
                else if (bet.betType.Equals("Number"))
                {
                    if (int.TryParse(bet.bet, out int numberBet))
                    {
                        if (numberBet >= 0 && numberBet <= 36)
                        {
                            check = true;
                        }
                        else { check = false; }
                    }
                }
            }
            else 
            {
                check = false;
            }

            return check;
        }
        public Roulette searchRoulette(List<Roulette> roulettes, int Id)
        {
            try
            {
                Roulette roulette = roulettes.FirstOrDefault(n => n.id == Id);

                return roulette;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int computeWinnerNumber()
        {
            Random _random = new Random();   
            int winnerNumber = _random.Next(0, 36);

            return winnerNumber;
        }
        public List<Bet> getBetsWinners(List<Bet> bets)
        {
            int winNumber = computeWinnerNumber();
            string colorNumber;
            if (winNumber % 2 == 0) { colorNumber = "Rojo"; } else { colorNumber = "Negro"; }
            List<Bet> betWinnerList = new List<Bet>();
            foreach (Bet bet in bets)
            {
                bool isnumber = int.TryParse(bet.bet, out int betnumber);
                if(betnumber == winNumber || bet.bet.Equals(colorNumber))
                {
                    betWinnerList.Add(bet);
                }
            };

            return betWinnerList;
        }
        public List<Winner> computeWinners(List<Bet> bets)
        {
            List<Winner> winners = new List<Winner>();
            foreach (Bet bet in bets)
            {
                Winner winner = new Winner();
                if (bet.betType.Equals("Number"))
                {
                    winner.amountWin = bet.amount * 5;
                    winner.Bet = bet;
                }
                else if (bet.betType.Equals("Color"))
                {
                    winner.amountWin = bet.amount * 1.8;
                    winner.Bet = bet;
                }
                winners.Add(winner);
            }

            return winners;
        }
    }
}
