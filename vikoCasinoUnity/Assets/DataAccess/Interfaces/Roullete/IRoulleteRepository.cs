using Assets.DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Interfaces.Roullete
{
    public interface IRoulleteRepository
    {
        public int GetRandomNumberOfTurns();
        public RoulleteBet GetWinBet(int x);

    }
}
