using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Gokkers
{
    public partial class Form1 : Form
    {
        public decimal Test;
        public string winningOstridge;
        public string secondOstridge;
        public string thirdOstridge;

        Guy[] guyArray = new Guy[3];
        Random Randomizer = new Random();
        Ostridge ostridge = new Ostridge();
        Ostridge[] ostridgeArray = new Ostridge[5];
        Random randomizer = new Random();
        int FerBet = 0;
        int SietseBet = 0;
        int LidyBet = 0;
        bool Bet = false;
        int RaceEndCounter = 0;
        public bool StopLocation = false;

        private void MakeOstridge()
        {
            ostridgeArray[0] = new Ostridge()
            {
                MyPictureBox = pictureBox5,
                Name = "Mythosis",
                StartingPosition = pictureBox1.Left,
                Randomizer = randomizer
                
                
            };
            ostridgeArray[1] = new Ostridge()
            {
                MyPictureBox = pictureBox2,
                Name = "The Light",
                StartingPosition = pictureBox2.Left,
                Randomizer = randomizer

            };
            ostridgeArray[2] = new Ostridge()
            {
                MyPictureBox = pictureBox3,
                Name = "Bolt",
                StartingPosition = pictureBox3.Left,
                Randomizer = randomizer
            };
            ostridgeArray[3] = new Ostridge()
            {
                MyPictureBox = pictureBox4,
                Name = "Sanic",
                StartingPosition = pictureBox3.Left,
                Randomizer = randomizer
            };
            ostridgeArray[4] = new Ostridge()
            {
                MyPictureBox = pictureBox6,
                Name = "Steel Wing",
                StartingPosition = pictureBox6.Left,
                Randomizer = randomizer
            };
        }
        private void MakeGuy()
        {
            guyArray[0] = new Guy
            {
                MyBet = null,
                Name = "Fer",
                Cash = 100,
                MyRadioButton = RBTN_Fer,
                MyLabel2 = lblFerbet,
                
            };
            guyArray[1] = new Guy
            {
                MyBet = null,
                Name = "Sietse",
                Cash = 100,
                MyRadioButton = RBTN_Sietse,
                MyLabel2 = lblSietsebet
                
            };
            guyArray[2] = new Guy
            {
                MyBet = null,
                Name = "Lidy",
                Cash = 100,
                MyRadioButton = RBTN_Lidy,
                MyLabel2 = lblLidybet
            };

        }


        // private PictureBox pictureBox1;
        //private PictureBox pictureBox2;
        // private PictureBox pictureBox3;
        //private PictureBox pictureBox4;
        private SoundPlayer _congosound;
        private SoundPlayer _soundPlayer;
        public Form1()
        {
            InitializeComponent();
            MakeOstridge();
            MakeGuy();
            guyArray[0].UpdateLabels();
            guyArray[1].UpdateLabels();
            guyArray[2].UpdateLabels();
            _congosound = new SoundPlayer("conga.wav");
            _soundPlayer = new SoundPlayer("winning.wav");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTN_Sietse.Enabled)

                lblBetter.Text = "Sietse";
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void RBTN_Fer_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTN_Fer.Enabled)

                lblBetter.Text = "fer";
            
        }

        private void lblBetter_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void RBTN_Lidy_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTN_Lidy.Enabled)

                lblBetter.Text = "Lidy";
        }

        
        private int EndCounter()
        {
            if (pictureBox5.Left == 0 )
            {
                RaceEndCounter += 1;
                return RaceEndCounter;

            }
            else
            {
                return 0;
            }
        }
        public bool RaceStop()
        {
            if (pictureBox5.Left == 250)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            for (int i = 0; i < ostridgeArray.Length; i++)
            {   
               
                ostridgeArray[i].Run();
                if (RaceEndCounter >= 3 && pictureBox5.Left >= 250)
                {
                    //pictureBox5.Dispose();
                    ostridgeArray[0].TakeStartingPosition();

                }     
                if ( ostridgeArray[i].Run() == true)
                {
                    timer1.Stop();
                    _congosound.Stop();
                    _soundPlayer.Play();
                    secondOstridge = ostridgeArray[i].Name;
                    thirdOstridge = ostridgeArray[i].Name;
                    MessageBox.Show(ostridgeArray[i].Name + " has won the race!");
                    winningOstridge = ostridgeArray[i].Name;
                    ostridgeArray[i].TakeStartingPosition();
                    i = ostridgeArray.Length;
                    racebutton.Enabled = true;
                    guyArray[0].Collect(winningOstridge);
                    guyArray[1].Collect(winningOstridge);
                    guyArray[2].Collect(winningOstridge);
                    timer2.Start();
                }

            }
         

        }

      

        private void racebutton_Click(object sender, EventArgs e)
        {

            
            _congosound.Play();
            ostridgeArray[0].TakeStartingPosition();
            ostridgeArray[1].TakeStartingPosition();
            ostridgeArray[2].TakeStartingPosition();
            ostridgeArray[3].TakeStartingPosition();
            ostridgeArray[4].TakeStartingPosition();
            pictureBox5.Left = 0;
            pictureBox2.Left = 0;
            pictureBox3.Left = 0;
            pictureBox4.Left = 0;
            pictureBox6.Left = 0;
            EndCounter();
           
            SietseBet = 0;
            LidyBet = 0;
            FerBet = 0;
            racebutton.Enabled = false;
            timer1.Start();
            
        }

        // betting system
        private void btnBet_Click(object sender, EventArgs e)
        {
            if (RBTN_Fer.Checked == true)
            {
                if (FerBet == 0)
                {

                    Bet = guyArray[0].Placebets(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString());
                    if (Bet == true)
                    {
                        FerBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Fer has already placed a bet.");
                }
            }
            if (RBTN_Sietse.Checked == true)
            {
                if (SietseBet == 0)
                {

                    Bet = guyArray[1].Placebets(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString());
                    if (Bet == true)
                    {
                        SietseBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Sietse has already placed a bet.");
                }
            }
            if (RBTN_Lidy.Checked == true)
            {
                if (LidyBet == 0)
                {

                    Bet = guyArray[2].Placebets(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString());
                    if (Bet == true)
                    {
                        LidyBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Fer has already placed a bet.");
                }
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 20;
            for (int i = 0; i < ostridgeArray.Length; i++)
            {

                ostridgeArray[i].SecondRun();
                if (ostridgeArray[i].SecondRun() == true)
                {
                    timer2.Stop();
                    _congosound.Stop();
                    _soundPlayer.Play();
                    MessageBox.Show(ostridgeArray[i].Name + " has become second!");
                    winningOstridge = ostridgeArray[i].Name;
                    ostridgeArray[i].TakeStartingPosition();
                    i = ostridgeArray.Length;
                    timer3.Start();
                }
                
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 20;
            for (int i = 0; i < ostridgeArray.Length; i++)
            {

                ostridgeArray[i].ThirdRun();
                if (ostridgeArray[i].ThirdRun() == true)
                {
                    timer3.Stop();
                    _congosound.Stop();
                    MessageBox.Show(ostridgeArray[i].Name + " has become third!");
                    winningOstridge = ostridgeArray[i].Name;
                    ostridgeArray[i].TakeStartingPosition();
                    i = ostridgeArray.Length;
                    racebutton.Enabled = true;
                    ostridgeArray[0].TakeStartingPosition();
                    ostridgeArray[1].TakeStartingPosition();
                    ostridgeArray[2].TakeStartingPosition();
                    ostridgeArray[3].TakeStartingPosition();
                    ostridgeArray[4].TakeStartingPosition();
                    pictureBox5.Left = 0;
                    pictureBox2.Left = 0;
                    pictureBox3.Left = 0;
                    pictureBox4.Left = 0;
                    pictureBox6.Left = 0;
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Enabled)
            {
                MessageBox.Show("easter egg found!");
                guyArray[0].Cash = +200;
                guyArray[1].Cash = +200;
                guyArray[2].Cash = +200;
               
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                
        }
    }
}
