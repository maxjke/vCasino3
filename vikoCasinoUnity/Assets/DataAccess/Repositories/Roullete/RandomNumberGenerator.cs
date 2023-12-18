using Assets.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GetRandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
