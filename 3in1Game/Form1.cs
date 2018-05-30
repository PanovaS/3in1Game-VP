using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3in1Game
{
    public partial class Form1 : Form
    {


        bool allowClick = false;
        PictureBox firstGuess;
        Random rnd = new Random();
        Timer clickTimer = new Timer();
      
        int time = 60;
        Timer timer = new Timer
        {
            Interval = 1000
        };



        public Form1()
        {
            InitializeComponent();
            setRandomImages();
            HideImages();
            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;

        }

        private PictureBox[] pictureBoxes {

            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> images
        {
            get
            {

                return new Image[] {

    Properties.Resources._0, Properties.Resources._1, Properties.Resources._2,
   Properties.Resources._3, Properties.Resources._4, Properties.Resources._5,
                    Properties.Resources._6, Properties.Resources._7
};
            }
        }

        public void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Out of time");
                    ResetImage();
                }
                var ssTime = TimeSpan.FromSeconds(time);
               label1.Text = "00: " + time.ToString();
            };
        }


        public void ResetImage()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
            HideImages();
            setRandomImages();
            time = 60;
            timer.Start();
        }
        public void HideImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Image = Properties.Resources.question;
            }
        }


        private PictureBox getFreeSlot()
        {
            int num;
            do
            {
                num = rnd.Next(0, pictureBoxes.Count());

            }
            while (pictureBoxes[num].Tag != null);
            return pictureBoxes[num];
        }
        private void setRandomImages()
        {
            foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }
        }

        private void clickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;
            var pic = (PictureBox)sender;
            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;
            if (pic.Image == firstGuess.Image && pic != firstGuess)
            {
                pic.Visible = firstGuess.Visible = false;
                {
                    firstGuess = pic;
                }
                HideImages();



            }
            else
            {

                allowClick = false;
                clickTimer.Start();

            }
            firstGuess = null;
            if (pictureBoxes.Any(p => p.Visible)) return;
            MessageBox.Show("You win,try again");
            ResetImage();




        }







        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();
            allowClick = true;
            clickTimer.Stop();

        }

        private void Start_Click(object sender, EventArgs e)
        {
            allowClick = true;
            startGameTimer();
        }








        /*  private void startGame(object sender, EventArgs e)
           {
               allowClick = true;
               setRandomImages();
               HideImages();
               startGameTimer();
               clickTimer.Interval = 1000;            
               clickTimer.Tick += CLICKTIMER_TICK;
              button1.Enabled = false;
           }
           */

    }
}
