﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Gokkers
{
    public partial class Form1 : Form
    {
        public decimal Test;
        public string winningOstridge;

        Guy[] guyArray = new Guy[3];
        Random Randomizer = new Random();
        Ostridge ostridge = new Ostridge();
        Ostridge[] ostridgeArray = new Ostridge[4];
        Random randomizer = new Random();
        int FerBet = 0;
        int SietseBet = 0;
        int LidyBet = 0;
        bool Bet = false;

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

        public Form1()
        {
            InitializeComponent();
            MakeOstridge();
            MakeGuy();
            guyArray[0].UpdateLabels();
            guyArray[1].UpdateLabels();
            guyArray[2].UpdateLabels();

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
        public bool Winner = false;

        

        

       

        private void BTN_reset_Click(object sender, EventArgs e)
        {
            pictureBox5.Left = 0;
            pictureBox2.Left = 0;
            pictureBox3.Left = 0;
            pictureBox4.Left = 0;
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //pictureBox5.Location = new Point(pictureBox5.Location.X + ostridge.Move(), pictureBox5.Location.Y);
            //pictureBox2.Location = new Point(pictureBox2.Location.X + ostridge.Move(), pictureBox2.Location.Y);
            // pictureBox3.Location = new Point(pictureBox3.Location.X + ostridge.Move(), pictureBox3.Location.Y);
            //pictureBox4.Location = new Point(pictureBox4.Location.X + ostridge.Move(), pictureBox4.Location.Y);
            for (int i = 0; i < ostridgeArray.Length; i++)
            {

                 ostridgeArray[i].Run();
                if ( ostridgeArray[i].Run() == true)
                {
                    // dogsArray[i].Run() = true;
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show(ostridgeArray[i].Name + " has won the race");
                    winningOstridge = ostridgeArray[i].Name;
                    i = ostridgeArray.Length;
                    racebutton.Enabled = true;
                    //ostridgeArray[0].Collect(winningDog);
                    //guyArray[1].Collect(winningDog);
                    //guyArray[2].Collect(winningDog);
                    guyArray[0].Collect(winningOstridge);
                    guyArray[1].Collect(winningOstridge);
                    guyArray[2].Collect(winningOstridge);


                    // guyArray[0].ClearBet();
                    // guyArray[1].ClearBet();
                    // guyArray[2].ClearBet();
                }

            }
            

            //stopRace();


        }



        public void stopRace()
        {
        }
      

        private void racebutton_Click(object sender, EventArgs e)
        {

            ostridgeArray[0].TakeStartingPosition();
            ostridgeArray[1].TakeStartingPosition();
            ostridgeArray[2].TakeStartingPosition();
            ostridgeArray[3].TakeStartingPosition();
            SietseBet = 0;
            LidyBet = 0;
            FerBet = 0;
            racebutton.Enabled = false;
            timer1.Start();
        }

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
    }
}