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
    public partial class FirstPart : Form
    {
        bool allowClick = false;
        PictureBox firstGuess;
        Random r = new Random();
        int time = 60;
        public static int points=0;
        
        public FirstPart()
        {
            InitializeComponent();
            setRandomImages();
            HideImages();
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
             Properties.Resources._6, Properties.Resources._7 };
            }
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
            timer1.Start();
        }
        public void HideImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Image = Properties.Resources.Question1;
            }
        }


        private PictureBox getFreeSlot()
        {
            int num;
            do
            {
                num = r.Next(0, pictureBoxes.Count());
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
            var pic = (PictureBox)sender;
            if (!allowClick) return;
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
                timer2.Start();
            }
            firstGuess = null;
            if (pictureBoxes.Any(p => p.Visible)) return;


            DialogResult res = MessageBox.Show("You win,go to the next level");
            if (res == DialogResult.OK)
            {
                timer1.Stop();
                this.Dispose();
            }      
            if(pictureBoxes.Count()!=0)
            ResetImage();          

        }
               
      
        private void timer2_Tick(object sender, EventArgs e)
        {
            HideImages();
            timer2.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if (time < 0)
            {
                timer1.Stop();
                MessageBox.Show("Out of time");
                ResetImage();
            }
            if (time.ToString().Length == 1)
            {
                label1.Text = "00:0" + time.ToString();
            }
            else
            {
                label1.Text = "00: " + time.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = new ThirdPart();
            res.Show();
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowClick = true;
            timer1.Start();
        }
    }
}
