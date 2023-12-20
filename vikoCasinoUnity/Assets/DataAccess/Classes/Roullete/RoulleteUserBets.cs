using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Roullete
{
    public class RoulleteUserBets : RoulleteBet
    {
        public int Amount { get; }
        public RoulleteUserBets(RoulleteColors color, int number) : base(color, number)
        {
        }

        public RoulleteUserBets(RoulleteColors color, int number,int amount) : base(color, number)
        {
            this.Amount = amount;
        }
    }
}
