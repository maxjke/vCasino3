using Assets.DataAccess.Classes;
using Assets.DataAccess.Interfaces;
using Assets.DataAccess.Interfaces.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories
{
    public class RoulleteRepository : IRoulleteRepository
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
