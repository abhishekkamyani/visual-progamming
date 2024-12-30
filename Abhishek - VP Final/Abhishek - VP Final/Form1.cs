using System;
using System.Data;
using System.Windows.Forms;

namespace Abhishek___VP_Final
{

    public partial class Form1 : Form
    {
        static DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Number");
            dt.Columns.Add("*");
            dt.Columns.Add("count");
            dt.Columns.Add("=");
            dt.Columns.Add("Result");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int inputValue = Convert.ToInt32(input.Text);

            for (int i = 1; i <= 10; i++)
            {

                dt.Rows.Add(inputValue, "*", i, "=", inputValue*i);
            }

            dgv.DataSource = dt;
        }
    }
}
