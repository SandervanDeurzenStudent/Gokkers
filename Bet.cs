using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gokkers
{
    class Bet : Ostridge
    {
        public decimal Amount;
        public string Ostridge;
        public Guy Bettor;
        
        public decimal PayOut(string Winner)
        {
            if (Winner == Ostridge)
                return Amount * 1;
            else
                return (0 - Amount);
        }
    }
}
