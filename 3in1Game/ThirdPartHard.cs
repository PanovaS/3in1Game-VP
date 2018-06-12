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
    public partial class ThirdPartHard : Form
    {



        public List<Words> words { get; set; }
        public Words word { get; set; }
        public Words selectWord { get; set; }
        public bool clicked { get; set; }
        public FirstPartHard form1 { get; set; }
        public Login loginForm;

        int time = 25;
        Timer timer = new Timer
        {
            Interval = 1000
        };

        public ThirdPartHard()
        {
            InitializeComponent();
            this.Size = new Size(950, 700);
            words = new List<Words>();
            word = new Words();
            lblPoints.Text = FirstPartHard.points.ToString();
            Fill();
            HideLabels();
            Selected();
            startGameTimer();
        }
        public void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time <= 0)
                {
                    timer.Stop();
                    label8.Visible = true;
                    label9.Visible = false;
                    GameOver();

                }
                var ssTime = TimeSpan.FromSeconds(time);
                lblText.Text = "00: " + time.ToString();
            };
        }
        public void GameOver()
        {
            timer.Stop();
            DialogResult dialog = MessageBox.Show("End of the game\n\nTotal points: " + FirstPartHard.points + " ", "Do you want to play again?", MessageBoxButtons.YesNoCancel);
            if (dialog == DialogResult.Yes)
            {

                loginForm = new Login();
                this.Close();
                loginForm.Show();
            }
            else if (dialog == DialogResult.No)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.Cancel)
            {
                lblText.Text = "00: " + "00";
            }


        }

        public void HideLabels()
        {
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Image = Properties.Resources.MovieQuestion;
        }

        public void Fill()
        {
            word.MovieName = "MALEFICENT";
            word.movieAssociation.Add("Angelina Jolie");
            word.movieAssociation.Add("Evil");
            word.movieAssociation.Add("Noxious");
            word.movieAssociation.Add("Sleeping Beauty");
            word.movieAssociation.Add("Vicious");
            word.movieAssociation.Add("Hostile");
            word.image = Properties.Resources.Maleficent;
            words.Add(word);

            word = new Words();
            word.MovieName = "GOSSIP GIRL";
            word.movieAssociation.Add("Blake Lively");
            word.movieAssociation.Add("Empire State");
            word.movieAssociation.Add("Chatter");
            word.movieAssociation.Add("Female");
            word.movieAssociation.Add("Series");
            word.movieAssociation.Add("Defamation");
            word.image = Properties.Resources.Gossip_girl;
            words.Add(word);

            word = new Words();
            word.MovieName = "LA LA LAND";
            word.movieAssociation.Add("Ryan Gosling");
            word.movieAssociation.Add("Jazz pianist");
            word.movieAssociation.Add("Love story");
            word.movieAssociation.Add("Emma Stone");
            word.movieAssociation.Add("Ground");
            word.movieAssociation.Add("Los Angeles");
            word.image = Properties.Resources.lalaLand;
            words.Add(word);

            word = new Words();
            word.MovieName = "TITANIC";
            word.movieAssociation.Add("Leonardo DiCaprio");
            word.movieAssociation.Add("Ship");
            word.movieAssociation.Add("Iceberg");
            word.movieAssociation.Add("Sink");
            word.movieAssociation.Add("Passengers");
            word.movieAssociation.Add("Ocean");
            word.image = Properties.Resources.Titanic;
            words.Add(word);

            word = new Words();
            word.MovieName = "DEADPOOL";
            word.movieAssociation.Add("Ryan Reynolds");
            word.movieAssociation.Add("Superhero");
            word.movieAssociation.Add("Revenge");
            word.movieAssociation.Add("Healing powers");
            word.movieAssociation.Add("Oscar");
            word.movieAssociation.Add("Dying");
            word.image = Properties.Resources.Deadpool;
            words.Add(word);

            word = new Words();
            word.MovieName = "WONDER WOMAN";
            word.movieAssociation.Add("Gal Gadot");
            word.movieAssociation.Add("Female");
            word.movieAssociation.Add("Amazonian warrior");
            word.movieAssociation.Add("Fighting in war");
            word.movieAssociation.Add("Girl power");
            word.movieAssociation.Add("Superhero movie");
            word.image = Properties.Resources.wonder;
            words.Add(word);


        }

        public void Selected()
        {
            Random r = new Random();
            int indeks = r.Next(0, 6);
            selectWord = words.ElementAt(indeks);
            lbl1.Text = selectWord.movieAssociation.ElementAt(r.Next(0, 6));
            lbl2.Text = selectWord.movieAssociation.ElementAt(r.Next(0, 6));
            lbl3.Text = selectWord.movieAssociation.ElementAt(r.Next(0, 6));
            while (lbl2.Text == lbl1.Text)
            {
                lbl2.Text = selectWord.movieAssociation.ElementAt(r.Next(0, 6));
            }
            while (lbl3.Text == lbl2.Text || lbl3.Text == lbl1.Text)
            {
                lbl3.Text = selectWord.movieAssociation.ElementAt(r.Next(0, 6));

            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            lbl1.Visible = true;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            lbl3.Visible = true;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            lbl2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = selectWord.image;
            clicked = true;
        }
        public void GuessWord()
        {

            if (txtName.Text.ToUpper() == selectWord.MovieName)
            {
                if (lbl2.Visible == true && lbl3.Visible == true && clicked == true)
                {
                    FirstPartHard.points += 5;
                }
                else
                {
                    if (lbl2.Visible == false)
                    {
                        FirstPartHard.points += 5;
                    }
                    if (lbl3.Visible == false)
                    {
                        FirstPartHard.points += 5;
                    }
                    if (clicked == false)
                    {
                        FirstPartHard.points += 10;
                    }
                }
                string s1 = "";
                Guess.Enabled = false;
                s1 += "Congratulations " + Login.i.Ime + ", you hit the movie!";
                label9.Visible = false;
                label7.Text = s1;
                label7.Visible = true;
                lblPoints.Text = FirstPartHard.points.ToString();
                GameOver();
            }
            else
            {
                label9.Visible = true;
            }

        }
        public void bestPlayers()
        {

            if (Login.igrachi.Contains(Login.i) && Login.i.Poeni == FirstPartHard.points)
            {

            }
            else
            {
                Login.i.Poeni = FirstPartHard.points;

                Login.igrachi.Add(Login.i);
            }
            Login.igrachi = Login.igrachi.OrderByDescending(x => x.Poeni).ToList();

            string s = "";
            int br = Login.igrachi.Count;

            if (br > 3)
            {
                br = 3;
            }
            for (int i = 0; i < br; i++)
            {
                s += Login.igrachi.ElementAt(i).Ime + "\t Total points: " + Login.igrachi.ElementAt(i).Poeni + "\t Mode: " + Login.igrachi.ElementAt(i).Mode + "\n";

            }

            MessageBox.Show(s, "Best players: ");

        }

        private void Guess_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "") GuessWord();
            else MessageBox.Show("Enter movie name!");
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Enter movie name!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void bestPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bestPlayers();
        }

        private void playAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            DialogResult dialog = MessageBox.Show("Are you sure?", "Do you want to play again?", MessageBoxButtons.YesNoCancel);
            if (dialog == DialogResult.Yes)
            {

                loginForm = new Login();
                this.Close();
                loginForm.Show();
            }
            else if (dialog == DialogResult.No)
            {
                Application.Exit();
            }

        }
    }
}