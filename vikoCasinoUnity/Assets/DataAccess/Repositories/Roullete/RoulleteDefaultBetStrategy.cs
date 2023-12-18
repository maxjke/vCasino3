using Assets.DataAccess.Classes;
using Assets.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories
{
    public class RoulleteDefaultBetStrategy : IBetStrategy
    {
        public RoulleteBet DetermineWinningBet(int x)
        {
            switch (x)
            {
                case 0:
                    return new RoulleteBet(RoulleteColors.Green, 0);
                case 1:
                    return new RoulleteBet(RoulleteColors.Red, 32);
                case 2:
                    return new RoulleteBet(RoulleteColors.Black, 15);
                case 3:
                    return new RoulleteBet(RoulleteColors.Red, 19);
                case 4:
                    return new RoulleteBet(RoulleteColors.Black, 4);
                case 5:
                    return new RoulleteBet(RoulleteColors.Red, 21);
                case 6:
                    return new RoulleteBet(RoulleteColors.Black, 2);
                case 7:
                    return new RoulleteBet(RoulleteColors.Red, 25);
                case 8:
                    return new RoulleteBet(RoulleteColors.Black, 17);
                case 9:
                    return new RoulleteBet(RoulleteColors.Red, 34);
                case 10:
                    return new RoulleteBet(RoulleteColors.Black, 6);
                case 11:
                    return new RoulleteBet(RoulleteColors.Red, 27);
                case 12:
                    return new RoulleteBet(RoulleteColors.Black, 13);
                case 13:
                    return new RoulleteBet(RoulleteColors.Red, 36);
                case 14:
                    return new RoulleteBet(RoulleteColors.Black, 11);
                case 15:
                    return new RoulleteBet(RoulleteColors.Red, 30);
                case 16:
                    return new RoulleteBet(RoulleteColors.Black, 8);
                case 17:
                    return new RoulleteBet(RoulleteColors.Red, 23);
                case 18:
                    return new RoulleteBet(RoulleteColors.Black, 10);
                case 19:
                    return new RoulleteBet(RoulleteColors.Red, 5);
                case 20:
                    return new RoulleteBet(RoulleteColors.Black, 24);
                case 21:
                    return new RoulleteBet(RoulleteColors.Red, 16);
                case 22:
                    return new RoulleteBet(RoulleteColors.Black, 33);
                case 23:
                    return new RoulleteBet(RoulleteColors.Red, 1);
                case 24:
                    return new RoulleteBet(RoulleteColors.Black, 20);
                case 25:
                    return new RoulleteBet(RoulleteColors.Red, 14);
                case 26:
                    return new RoulleteBet(RoulleteColors.Black, 31);   
                case 27:
                    return new RoulleteBet(RoulleteColors.Red, 9);
                case 28:
                    return new RoulleteBet(RoulleteColors.Black, 22);
                case 29:
                    return new RoulleteBet(RoulleteColors.Red, 18);
                case 30:
                    return new RoulleteBet(RoulleteColors.Black, 29);
                case 31:
                    return new RoulleteBet(RoulleteColors.Red, 7);
                case 32:
                    return new RoulleteBet(RoulleteColors.Black, 28);
                case 33:
                    return new RoulleteBet(RoulleteColors.Red, 12);
                case 34:
                    return new RoulleteBet(RoulleteColors.Black, 35);
                case 35:
                    return new RoulleteBet(RoulleteColors.Red, 3);
                case 36:
                    return new RoulleteBet(RoulleteColors.Black, 26);
                default:
                    return new RoulleteBet(RoulleteColors.Green, 333);
            }
        }
    }
}
