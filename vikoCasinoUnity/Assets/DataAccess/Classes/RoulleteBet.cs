using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes
{
    public class RoulleteBet
    {
        public RoulleteBet(RoulleteColors color, int number)
        {
            Color = color;
            Number = number;
        }

        public RoulleteColors Color { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"{this.Number} {this.Color}";
        }
    }
}
