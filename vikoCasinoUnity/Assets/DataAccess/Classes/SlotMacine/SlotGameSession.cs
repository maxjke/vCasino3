using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.SlotMacine
{
    public class SlotGameSession
    {
        public SlotMachineBet WonBet { get; set; }

        public decimal balanceChange { get; set; }
        public bool CanWeBet { get; set; } = true;
    }
}
