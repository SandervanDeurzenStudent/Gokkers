using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace Gokkers
{
    class Ostridge
    {
        public int RaceTrackLength;
        public int RaceTrackSecond;
        public int StartingPosition = 0;
        
        public string Name;
        public PictureBox MyPictureBox = null;
        public bool Winner = false;
        public bool Second = false;
        public bool Third = false;
        public int Location = 0;
        public Random Randomizer = new Random();

        
        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
        public int GetRaceTrackSecond()
        {
            this.RaceTrackSecond = 610;
            return this.RaceTrackSecond;
        }
        public int GetRaceTrackLength()
        {
            this.RaceTrackLength = 605;
            return this.RaceTrackLength;
        }

        public bool Run()
        {
            int move = Randomizer.Next(1, 6);
            
            Location = Location + move;
            MyPictureBox.Left = StartingPosition + Location;
            if (MyPictureBox.Left >= GetRaceTrackLength())
            {
                Winner = true;
                return true;
            }
            if (MyPictureBox.Left >= GetRaceTrackSecond())
            {
              
                Second = true;
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool SecondRun()
        {
            int move = Randomizer.Next(1, 6);

            Location = Location + move;
            MyPictureBox.Left = StartingPosition + Location;
            if (MyPictureBox.Left >= GetRaceTrackLength())
            {

                Winner = true;
                Third = true;

                return true;
            }
            if (MyPictureBox.Left >= GetRaceTrackSecond() && MyPictureBox.Left <= GetRaceTrackLength())
            {

                Second = true;
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool ThirdRun()
        {
            int move = Randomizer.Next(1, 6);

            Location = Location + move;
            MyPictureBox.Left = StartingPosition + Location;
            if (MyPictureBox.Left >= GetRaceTrackLength())
            {

                Winner = true;
                Third = true;

                return true;
            }
            if (MyPictureBox.Left >= GetRaceTrackSecond() && MyPictureBox.Left <= GetRaceTrackLength())
            {

                Second = true;
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
