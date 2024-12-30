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

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog openFileDialog;

        static int count = 1;
        String path = "F:\\OneDrive\\5th Semester\\WEB ENG\\Tasks\\Image Changer\\Images\\";
        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.BackColor = SystemColors.ControlLight;
            textBox2.Text = "Write your name";
            linkLabel1.Text = "GitHub";

            openFileDialog = new OpenFileDialog();

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(linkLabel1, "Click to open my github profile");
            tooltip.SetToolTip(textBox2, "Write your name");

            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("age", "Age");
            dataGridView1.Columns.Add("gender", "Gender");
            dataGridView1.Rows.Add("Abhishek", 23, "Male");
            dataGridView1.Rows.Add("Harry", 40, "Male");

            button1.Text = "Open Color Dialog";
            button1.BackColor = SystemColors.GrayText;
            button1.ForeColor = SystemColors.ControlLight;
            button1.Font = SystemFonts.DialogFont;

            button2.Text = "Open Font Dialog";

            listView1.View = View.Details;
            listView1.Columns.Add("Subjects", 50);
            //listView1.Items.Add("Item 1");
            //listView1.Items.Add("Item 2");

            listBox1.Items.Add("Apple");
            listBox1.Items.Add("Banana");
            listBox1.Items.Add("Cherry");

            groupBox1.Text = "Gender";
            genderMale.Text = "Male";
            genderFemale.Text = "Female";

            pictureBox1.Image = Image.FromFile(path + count + ".jpg");

            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += Timer1_Tick;
            timer.Start();

            progressBar1.Value = 0;
            
            backgroundWorker1.WorkerReportsProgress = true;
            //backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            count = count < 7 ? ++count : 1;
            pictureBox1.Image = Image.FromFile(path + count + ".jpg");
            //textBox2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.github.com/abhishekkamyani");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "(*.jpg; *.png; *.jpeg)|*.jpg;*.png;*jpeg";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog.FileName;
                MessageBox.Show(openFileDialog.FileName, "Selected File");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox1.SelectedItem.ToString();
        }

        private void genderMale_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (genderMale.Checked)
            {
                dataGridView1.Rows.Add("RandomName", "RandomAge", "Male");
            }
            else if (genderFemale.Checked)
            {
                dataGridView1.Rows.Add("RandomName", "RandomAge", "Female");
            }
            else
            {
                MessageBox.Show("No Gender is selected");
            }

            if (subjectEnglish.Checked)
            {
                listView1.Items.Add("English");
            }
            if (subjectMaths.Checked)
            {
                listView1.Items.Add("Maths");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(90);
                //backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
                backgroundWorker1.ReportProgress(0);

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += 1;
            textBox2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Work Completed");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = dateTimePicker1.Value.ToString();
        }

        private void pointerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
    }
}
