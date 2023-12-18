using Assets.DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Interfaces
{
    public interface IBetStrategy
    {
        RoulleteBet DetermineWinningBet(int x);
    }
}
