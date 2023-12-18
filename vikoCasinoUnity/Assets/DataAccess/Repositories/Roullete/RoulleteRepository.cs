using Assets.DataAccess.Classes;
using Assets.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories
{
    public class RoulleteRepository 
    {
        private IBetStrategy betStrategy;
        private IRandomNumberGenerator randomNumberGenerator;

        public RoulleteRepository(IBetStrategy betStrategy, IRandomNumberGenerator randomNumber)
        {
            this.betStrategy = betStrategy;
            this.randomNumberGenerator = randomNumber;
        }

        public int GetRandomNumberOfTurns()
        {
            return randomNumberGenerator.GetRandomNumber(75,150);
        }

        public RoulleteBet GetWinBet(int x)
        {
            return betStrategy.DetermineWinningBet(x);
        }
    }
}
