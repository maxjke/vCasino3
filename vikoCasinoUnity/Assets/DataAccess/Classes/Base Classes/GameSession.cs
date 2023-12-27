﻿using Assets.DataAccess.Classes.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Roullete
{
    public class GameSession<Tbet> where Tbet : Bet
    {
        public List<Tbet> Bets { get; set; } = new List<Tbet>();
        public RouletteBet WonBet { get; set; }

        public decimal balanceChange { get; set; }

    }
}