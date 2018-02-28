using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gokkers
{
    class Guy: Bet
    {
        public decimal Cash;
        public Bet MyBet;
        
        public RadioButton MyRadioButton;
        
        public Label MyLabel2;
        
        


        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has $" + Cash;
           
        }

        public void ClearBet()
        {
            MyBet = null;
            MyLabel2.Text = Name + " hasn't placed a bet";
        }
        public bool Placebets(int BetAmount, string OstridgeToWin)
        {
            this.MyBet = new Bet() { Amount = BetAmount, Ostridge = OstridgeToWin, Bettor = this };
            if (BetAmount <= Cash)
            {
                MyLabel2.Text = this.Name + " bets " + BetAmount + " dollars on " + OstridgeToWin;
                this.UpdateLabels();
                return true;
            }

            else
            {
                MessageBox.Show(Name + " does not have enough to cover that bet");
                this.MyBet = null;
                return false;
            }

        }
        public bool PlaceBet(int BetAmount, string OstridgeToWin, decimal Test)
        {
            this.MyBet = new Bet() { Amount = BetAmount, Ostridge = OstridgeToWin, Bettor = this};
            if (BetAmount <= Cash)
            {
                MyLabel2.Text = this.Name + " bets " + BetAmount + " dollars on " + OstridgeToWin;
                this.UpdateLabels();
                UpdateLabels();
                return true;
            }
            else
            {
                MessageBox.Show(Name + " does not have enough to cover that bet ");
                this.MyBet = null;
                return false;
            }
        }

        public void Collect(string Winner)
        {
            if (MyBet != null)
                Cash = Cash + MyBet.PayOut(Winner);
            ClearBet();
            UpdateLabels();
        }

    }
}
