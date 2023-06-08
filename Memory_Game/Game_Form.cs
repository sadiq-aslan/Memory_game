using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Game_Form : Form
    {
        public Game_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu.ls.Clear();
            Main_Menu m=new Main_Menu();
            m.Show();
        }
      

        private void Game_Form_Load(object sender, EventArgs e)
        {

            label4.Text = Main_Menu.ls[0].name;
            label6.Text = Main_Menu.ls[0].number_of_tiles.ToString();
            label8.Text = Main_Menu.ls[0].number_of_lives.ToString();




            for (int i = 0; i < Main_Menu.ls[0].board_size; i++)
            {
                for (int j = 0; j < Main_Menu.ls[0].board_size; j++)
                {
                    Button newButton = new Button();
                    this.Controls.Add(newButton);
                    newButton.Name = $"button,{i},{j}";
                    newButton.Location = new Point(i*80+200, j*80);
                    newButton.Size = new Size(70, 70);
                    newButton.BackColor = Color.Blue;
                  

                    //this.Controls[$"tb{i}{j + 1}"].Text = val1;

                    //for (int a = 0; a < Main_Menu.ls[0].number_of_tiles; a++)
                    //    this.Controls[$"button,{rd.Next(0, Main_Menu.ls[0].board_size - 1)},{rd.Next(0, Main_Menu.ls[0].board_size - 1)}"].Text = a.ToString(); 
                }
            }
          


        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
        int timer = Main_Menu.ls[0].showing_time;

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            label2.Text = timer.ToString();
            timer--;
            if (timer == 0)
            {
                timer1.Stop();


               hide();

                //        foreach (string item in btnname)
                //{
                //    this.Controls[item].ForeColor = Color.Blue;
                //}
                logic(0);
                timer2.Start();

            }
        }
        void hide()
        {
            for (int i = 0; i < Main_Menu.ls[0].board_size; i++)
            {
                for (int j = 0; j < Main_Menu.ls[0].board_size; j++)
                {
                    this.Controls[$"button,{i},{j}"].ForeColor = Color.Blue;
                }
            }
        }

        void delete() {
            for (int i = 0; i < Main_Menu.ls[0].board_size; i++)
            {
                for (int j = 0; j < Main_Menu.ls[0].board_size; j++)
                {
                    this.Controls[$"button,{i},{j}"].Text = string.Empty;
                }
            }
        }
           List<string> btnname = new List<string>();

        void unique() {
            Random rd = new Random();
                     int a = 1;
            
           
            while ((a <= Main_Menu.ls[0].number_of_tiles))
            {
                string btn = $"button,{rd.Next(0, Main_Menu.ls[0].board_size - 1)},{rd.Next(0, Main_Menu.ls[0].board_size - 1)}";
                btnname.Add(btn);
                if (btnname.Count != 1)
                {
                    for (int i = 0; i <= btnname.Count - 2; i++)
                    {
                        if (btnname[i] != btn)
                        {


                            if (i == btnname.Count - 2)
                            {
                                this.Controls[btn].Text = a.ToString();
                                a++;
                            }


                        }
                        else
                        {
                            btnname.Remove(btn);
                            break;
                        }
                        
                        



                    }
                }
                else
                {
                    this.Controls[btn].Text = a.ToString();
                    a++;
                    
                }
            }
        }
        void black() {
            foreach (string item in btnname) {
                this.Controls[item].ForeColor = Color.Black;
            }
        }
        List<string> tisl = new List<string>();

        void wrong() {

            for (int i = 0; i < Main_Menu.ls[0].board_size; i++)
            {
                for (int j = 0; j < Main_Menu.ls[0].board_size; j++)
                {
                    tisl.Add($"button,{i},{j}");

                   // this.Controls[$"button,{i},{j}"].Text = string.Empty;
                }
            }

            foreach (string item in btnname) 
            {
                tisl.Remove(item);

            }

            foreach (string item in tisl) {
                this.Controls[item].Click += Game_Form_Click1;
            }

           
       
            
        }

        private void Game_Form_Click1(object sender, EventArgs e)
        {
        //    if (Convert.ToInt16(label8.Text) >= 0)
        //    {
        //        Button clickedButton = sender as Button;
        //        clickedButton.BackColor = Color.Red;
        //        labeldcrs(label8);
        //    }
        //    else
        //    {
        //        timer2.Stop();

        //        MessageBox.Show("u have lost!");
        //        button1.Enabled = true;
        //        foreach (string item in tisl) {
        //            this.Controls[item].Click -= Game_Form_Click1;
        //        }
        //        tisl.Clear();
        //    }

        }
        void blue() {
            for (int i = 0; i < Main_Menu.ls[0].board_size; i++)
            {
                for (int j = 0; j < Main_Menu.ls[0].board_size; j++)
                {
                    this.Controls[$"button,{i},{j}"].BackColor = Color.Blue;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (timer != 0)
            {
                trigger(true);
                tisl.Clear();
                blue();
                unique();
               
                //  wrong();
                timer1.Start();
              button1.Enabled = false;
                button1.Text = "try again";

            }
            else if (Convert.ToInt16(label6.Text)==0||Convert.ToInt16(label8.Text)==0) {
                trigger(true);
                tisl.Clear();
                blue();
                delete();
                label6.Text = Main_Menu.ls[0].number_of_tiles.ToString();
                label8.Text = Main_Menu.ls[0].number_of_lives.ToString();

                index = 0;
                timer = Main_Menu.ls[0].showing_time;
                secondtimer = 0;
                btnname.Clear();
                unique();
          // wrong();
                 black();
                timer1.Start();
              button1.Enabled = false;

              
             
               

            }




        }
        void logic(int indx) {


            tisl.Clear();
          


            for (int i = 0; i < Main_Menu.ls[0].board_size; i++)
            {
                for (int j = 0; j < Main_Menu.ls[0].board_size; j++)
                {
                    tisl.Add($"button,{i},{j}");

                    // this.Controls[$"button,{i},{j}"].Text = string.Empty;
                }
            }
          
                tisl.Remove(btnname[indx]);
            
            

                foreach (string item in tisl)
                {
                    this.Controls[item].Click += Game_Form_Click2;

                }
            this.Controls[btnname[indx]].Click += Game_Form_Click;




        }

       


         int index = 0;
        void labeldcrs(Label label) 
        {
            int a = Convert.ToInt32(label.Text);
            a--;
            label.Text=a.ToString();
        }
        private void Game_Form_Click(object sender, EventArgs e)
        {
            tislremover();
            try
                {
                    this.Controls[btnname[index]].ForeColor = Color.Black;
                    this.Controls[btnname[index]].BackColor = Color.Green;
                    labeldcrs(label6);
                    this.Controls[btnname[index]].Click -= Game_Form_Click;
                   
                    tisl.Clear();
                    index++;
             
                    logic(index);


                }
                catch (Exception)
                {
              
              //  this.Controls[btnname[index]].Click -= Game_Form_Click;
                trigger(false);
                label6.Text = 0.ToString();
                    timer2.Stop();
                    button1.Enabled = true;
                btnname.Clear();
                    MessageBox.Show($"u won your time is {secondtimer - 1} ");
                }

          


        }
        void tislremover() {
            foreach (string item in tisl)
            {
                this.Controls[item].Click -= Game_Form_Click2;

            }
        }
        
        private void Game_Form_Click2(object sender, EventArgs e)
        {
            tislremover();

            if (Convert.ToInt16(label8.Text) >= 1)
            {
                this.Controls[btnname[index]].Click -= Game_Form_Click;
                labeldcrs(label8);
                Button clickedButton = sender as Button;
                clickedButton.BackColor = Color.Red;
                clickedButton.ForeColor = Color.Red;
               
             
                logic(index);

              
            }
            else {
              
               this.Controls[btnname[index]].Click -= Game_Form_Click;
                trigger(false);
                timer2.Stop();
                button1.Enabled = true;
                MessageBox.Show("u have lost ","information", MessageBoxButtons.OK, MessageBoxIcon.Question);
                btnname.Clear();
            }
        }
        void trigger(bool trigger) 
        {
            for (int i = 0; i < Main_Menu.ls[0].board_size; i++)
            {
                for (int j = 0; j < Main_Menu.ls[0].board_size; j++)
                {
                    this.Controls[$"button,{i},{j}"].Enabled = trigger;
                }
            }
        }

        int secondtimer = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {

            label2.Text = secondtimer.ToString();


            secondtimer++;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
