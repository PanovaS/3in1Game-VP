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
    public partial class Login : Form
    {
        FirstPart firstForm;
        FirstPartEasy firstFormEasy;
        FirstPartHard firstFormHard;
        public static string Player1 { set; get; }
        public static List<Player> igrachi = new List<Player>();
        public static Player i;

        public Login()
        {
            InitializeComponent();
            this.Size = new Size(950, 700);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void name_Validating(object sender, CancelEventArgs e)
        {
            if (name.Text == "")
            {
                errorProvider1.SetError(name, "Please enter name!");
            }
            else {
                errorProvider1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text != "") {
                Player1 = name.Text;
                i = new Player();
                i.Ime = Player1;
                i.Poeni = 0;
                i.Mode = comboBox1.SelectedItem.ToString();
                if (i.Mode.Equals("Medium"))
                {
                    firstForm = new FirstPart();
                    firstForm.Show();
                }
                else if (i.Mode.Equals("Easy"))
                {
                    firstFormEasy = new FirstPartEasy();
                    firstFormEasy.Show();

                }
                else {

                     firstFormHard = new FirstPartHard();
                     firstFormHard.Show();
                   firstFormHard.Location = this.Location;
                }
                this.Hide();
            }
        }
    }
}
