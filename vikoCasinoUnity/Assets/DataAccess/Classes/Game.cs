using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class Game
    {
        protected int WhatWeWin { get; set; }
        protected float NumberOfTurns { get; }
        protected bool CanWeTurn { get; }
        protected float Speed { get; }
    }
}
