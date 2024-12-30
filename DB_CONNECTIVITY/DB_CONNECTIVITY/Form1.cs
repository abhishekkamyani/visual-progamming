using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DB_CONNECTIVITY
{
    public partial class Form1 : Form
    {
        static string connection = "server=localhost; user=root; password=''; database=lms";
        string fetchQuery = "select * from students";
        MySqlConnection mySqlConnection =new MySqlConnection(connection);
        static int cmsid = 0;
        static string gender = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fetch();
        }

        private void fetch()
        {
            mySqlConnection.Open();

            MySqlCommand cmd = new MySqlCommand(fetchQuery, mySqlConnection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            mySqlConnection.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            mySqlConnection.Open();

            MySqlCommand cmd = new MySqlCommand(
    "INSERT INTO students (name, contact, gender) VALUES (@tb2, @tb3, @tb4)",
    mySqlConnection
);
            cmd.Parameters.Add("@tb2", MySqlDbType.VarChar).Value = name.Text;
            cmd.Parameters.Add("@tb3", MySqlDbType.VarChar).Value = contact.Text;
            cmd.Parameters.Add("@tb4", MySqlDbType.VarChar).Value = gender;

            cmd.ExecuteNonQuery();

            mySqlConnection.Close();
            fetch();

            name.Text = "";
            contact.Text = "";
            genderMale.Checked = false;
            genderFemale.Checked = false;
        }

        private void genderMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void genderFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmsid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            contact.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if(dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Male")
            {
                genderMale.Checked = true;
                genderFemale.Checked = false;
                gender = "Male";
            }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Female")
            {
                genderFemale.Checked = true;
                genderMale.Checked = false;
                gender = "Female";
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                mySqlConnection.Open();

                // Update query
                string query = "UPDATE students SET name = @name, contact = @contact, gender = @gender WHERE cmsid = @cmsid";

                // Create a MySqlCommand object
                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

                // Add parameters to prevent SQL injection
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;
                cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = contact.Text;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@cmsid", MySqlDbType.Int32).Value = cmsid; 

                // Execute the update query
                int rowsAffected = cmd.ExecuteNonQuery();
                mySqlConnection.Close();

                // Check if the update was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully.");
                    fetch();
                }
                else
                {
                    MessageBox.Show("No record found with the given cmsid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                mySqlConnection.Open();

                // Delete query
                string query = "DELETE FROM students WHERE cmsid = @cmsid";

                // Create a MySqlCommand object
                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

                // Add parameters to prevent SQL injection
                cmd.Parameters.Add("@cmsid", MySqlDbType.Int32).Value = cmsid; // Replace '1' with the ID of the record you want to delete

                // Execute the delete query
                int rowsAffected = cmd.ExecuteNonQuery();
                mySqlConnection.Close();

                // Check if the deletion was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record deleted successfully.");
                    fetch();
                }
                else
                {
                    MessageBox.Show("No record found with the given cmsid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
