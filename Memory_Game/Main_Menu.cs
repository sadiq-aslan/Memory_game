using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Custom...")
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
               

            }
            else {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox2.Text = string.Empty;
                textBox3.Text= string.Empty;
                textBox4.Text=string.Empty;
                textBox5.Text= string.Empty;    

            }
            switch (comboBox1.Text) {
                case "Easy":
                    textBox2.Text = 5.ToString();
                    textBox3.Text = 3.ToString();
                    textBox4.Text = 2.ToString();
                    textBox5.Text = 4.ToString();
                    break;

                case "Medium":
                    textBox2.Text = 6.ToString();
                    textBox3.Text = 2.ToString();
                    textBox4.Text = 1.ToString();
                    textBox5.Text = 5.ToString();
                    break;
                case "Hard":
                    textBox2.Text = 7.ToString();
                    textBox3.Text = 2.ToString();
                    textBox4.Text = 1.ToString();
                    textBox5.Text = 7.ToString();
                    break;
            }

        }
        public static List<Person> ls = new List<Person>();
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                Convert.ToInt32(textBox2.Text);
                Convert.ToInt32(textBox3.Text);
                Convert.ToInt32(textBox4.Text);
                Convert.ToInt32(textBox5.Text);

                if (Math.Pow(Convert.ToInt32(textBox2.Text), 2) * 0.7 > Convert.ToInt32(textBox5.Text))
                {
                    if (textBox1.Text.Length != 0)
                    {
                        Person p = new Person(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                        ls.Add(p);
                        this.Hide();
                        Game_Form gf = new Game_Form();
                        gf.Show();
                    }
                    else MessageBox.Show("Please add your name");
                }
                else
                {
                    Random rd = new Random();
                    DialogResult res = new DialogResult();
                   res= MessageBox.Show($"piles is bigger than 70% of {textBox2.Text}X{textBox2.Text} Matrix which is not recomended. \n Do u still want to continue?", "information", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        MessageBox.Show("i don't let you");
                    }
                    else
                        MessageBox.Show("OK then, decrease value of tiles");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please fulfill all gapes properly");           
            }
             
        }
    }
}
