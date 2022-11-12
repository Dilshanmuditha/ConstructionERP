using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class UpdateWorkers : Form
    {
        public UpdateWorkers()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string address = textBox3.Text;
            string name = textBox2.Text;
            string dob = textBox4.Text;

            SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");

            string update = "UPDATE workerDetails SET name= '" + name + "',address='" + address + "',dob='" + dob + "' WHERE Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(update, Constring);
            try
            {
                Constring.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Updated.");
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Workers workers = new Workers();
            workers.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            
        }

        private void UpdateWorkers_Enter(object sender, EventArgs e)
        {

            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string NIC = textBox1.Text;
            if(NIC == "") {
                label6.Text = "please enter id number";
            }
            else
            {
                int id = int.Parse(textBox1.Text);

                SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
                string Query = "Select * From workerDetails Where Id='" + id + "'";
                //string a = "Id ='"+ id + "'";
                SqlCommand cmd = new SqlCommand(Query, Constring);

                try
                {
                    Constring.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    
                    if (sdr.Read())
                    {
                        textBox2.Text = sdr["name"].ToString();
                        textBox3.Text = sdr["address"].ToString();
                        textBox4.Text = sdr["dob"].ToString();
                    }
                    else {
                        label6.Text = "*Not a Valid Id Number";
                        label6.ForeColor = Color.DarkOrange;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void UpdateWorkers_TextChanged(object sender, EventArgs e)
        {

           
        }
    }
}
