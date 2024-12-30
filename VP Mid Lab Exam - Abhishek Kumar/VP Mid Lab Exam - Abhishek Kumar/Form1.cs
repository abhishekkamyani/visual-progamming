using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Mid_Lab_Exam___Abhishek_Kumar
{
    public partial class Form1 : Form
    {
        static int hours = 0, minutes = 59, seconds = 55;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
            }
            if (minutes >= 60)
            {
                minutes = 0;
                hours++;
            }
            
            label2.Text = (hours < 10 ? "0" : "") + hours.ToString() + ":" + (minutes < 10 ? "0" : "") + minutes.ToString() + ":" + (seconds < 10 ? "0" : "") + seconds.ToString();
        }
    }
}
