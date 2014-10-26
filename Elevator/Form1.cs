using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elevator
{
    public partial class Form1 : Form
    {

        private Kone k = new Kone(7);
        private Thyssen t = new Thyssen(10);
        private Schindler sc = new Schindler(6);
        private Otis o = new Otis(5);
        int count = 0;
        Timer time = new Timer();
        Timer time2 = new Timer();
        bool canmove = true;


        public Form1()
        {   

            InitializeComponent();
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            KoneLabel.Text = "This elevator is at floor " + k.CurrentFloor;
            KoneLabel.Text += "\n" + "This elevator has maximun floors of " + k.MaxFloors; 
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OtisLabel.Text = "This elevator is at floor " + o.CurrentFloor;
            OtisLabel.Text += "\n" + "This elevator has maximun floors of " + o.MaxFloors; 
        }



        private void button3_Click(object sender, EventArgs e)
        {

            SchindlerLabel.Text = "This elevator is at floor " + sc.CurrentFloor;
            SchindlerLabel.Text += "\n" + "This elevator has maximun floors of " + sc.MaxFloors; 
        }

        private void button4_Click(object sender, EventArgs e)
        {   

            ThyssenLabel.Text = "This elevator is at floor " + t.CurrentFloor;
            ThyssenLabel.Text += "\n" + "This elevator has maximun floors of " + t.MaxFloors; 
            
        }

        private void button5_Click(object sender, EventArgs e) 
        {

            //await button6_Click ;
            if (k.AlarmOn)
            {
                KoneLabel.Text = "Alarm is on, elevator cannot move";
                return; 
            }
            try
            {
                int cf = k.CurrentFloor;
                int df = Convert.ToInt32(textBox1.Text); 
                int g = k.Goto(df);
                if (g == -1)
                {
                    KoneLabel.Text = "Invalid Floor Number";
                }
                else if(df > cf)  
                {
                    canmove = false;
                    k.Goto(cf);
                    count = df - cf;
                    time.Interval = 1000;
                    time.Tick += time_Tick;
                    time.Start();


                }
                else if (df < cf)
                {
                    canmove = false;
                    k.Goto(cf);
                    count = cf - df;
                    time2.Interval = 1000;
                    time2.Tick += time_Tick2;
                    time2.Start();
                }else
                    textBox8.Text = "Elevator at floor " + k.CurrentFloor;

                    
            }
            catch (FormatException)
            {
                    KoneLabel.Text = "Invalid Floor Number";
            }
            

        }

        private void time_Tick2(object sender, EventArgs e)
        {
            if (count <= 1)
            {
                time2.Stop();
                time2 = new Timer();
                canmove = true;
                return;
            }
            textBox8.Text = "Elevator is at floor " + k.Goto(k.CurrentFloor - 1);
            count--;


        }

        void time_Tick(object sender, EventArgs e)
        {

            if (count <= 1)
            {
                time.Stop();
                time = new Timer();
                canmove = true;
                return;
            }
            textBox8.Text = "Elevator is at floor " + k.Goto(k.CurrentFloor + 1);
            count--;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //await;
            if (canmove == false)
            {
                textBox7.Text = "Moving";
                return; 
            }
            if (k.IsOpen)
            {
                k.Close();
                textBox7.Text = "Closed";
            }
            else
            {
                k.Open();
                textBox7.Text = "Open";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            count = 0; 
            textBox5.Text = "Floor " + k.Stop().ToString(); 

            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (k.AlarmOn)
            {
                textBox6.Text = "Off";
                k.AlarmOn = false; 
            }
            else
            {
                textBox6.Text = "On";
                k.Alarm(); 
            }

        }

        



    }
}
