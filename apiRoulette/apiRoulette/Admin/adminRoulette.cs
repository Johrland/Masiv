using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRoulette.Admin
{
    public class adminRoulette
    {
        public int createRullete(int id, bool success)
        {
            if (success)
            {
                id = 1;
            }
            else
            {
                id = 2;
            }

            return id;
        }

    }
}
