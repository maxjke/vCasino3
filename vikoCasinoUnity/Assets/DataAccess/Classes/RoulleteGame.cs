using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class RoulleteGame : Game
    {
        public RoulleteGame():base("", new Random().Next(150, 300), true, 0.01f) 
        {
        }

    }
}
