using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Roullete
{
    public class GameSession
    {
        public List<RoulleteUserBets> Bets { get; set; } = new List<RoulleteUserBets>();
        public RoulleteBet WonBet { get; set; }

        public decimal balanceChange { get; set; }

    }
}
