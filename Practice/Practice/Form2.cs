using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form2 : Form
    {
        private int x = 50;
        private int y = 50;
        private Random random = new Random();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            timer1.Interval = 10;
            timer1.Start();

            timer2.Interval = 500;
            timer2.Start();

        }

            private void timer1_Tick(object sender, EventArgs e)
        {

            x++;
            while (x < 500)
            {
                x++;
                pictureBox1.Location = new Point(x, y);
            }

            //BackColor = Color.Red;
            while (y < 500)
            {
                y++;
                pictureBox1.Location = new Point(x, y);
            }
            //BackColor = Color.AliceBlue;
            while (x > 0)
            {
                x--;
                pictureBox1.Location = new Point(x, y);
            }
            //BackColor = Color.Yellow;

            while (y > 0)
            {
                y--;
                pictureBox1.Location = new Point(x, y);
            }

            while (x < 250 && y < 250)
            {
                x++;
                y++;

                pictureBox1.Location = new Point(x, y);
            }
            //BackColor = Color.Green;


            // after visiting all four sides, now place it to the center
            Thread.Sleep(1000);
            pictureBox1.Location = new Point(250, 250);
            Thread.Sleep(1000);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);
            label1.Text = r + ", " + g + ", " + b;
            this.BackColor = Color.FromArgb(r, g, b);
        }
    }

}
