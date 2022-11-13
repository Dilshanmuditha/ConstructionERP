using Construction.Expenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Construction.Project
{
    public partial class UpdateProject : Form
    {
        public UpdateProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ProjectDetails.sendtext);

            string name = textBox1.Text;
            string location = textBox2.Text;
            string clientName = textBox3.Text;
            string clientNumber = textBox4.Text;
            string pmName = textBox5.Text;
            string desc = textBox6.Text;
            double budget = double.Parse(textBox7.Text);
            DateTime date = DateTime.Today;
            DateTime time = DateTime.Now;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
            string update = "UPDATE Project SET Project_Name = '" + name + "',Location='" + location + "',Client_Name='" + clientName + "',Client_Number='" + clientNumber + "',PM_Name='" + pmName + "',Description='" + desc + "',Budget='" + budget + "',date='" + date + "',time='" + time + "' WHERE Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(update, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Updated.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void UpdateProject_Load(object sender, EventArgs e)
        {

            int id = int.Parse(ProjectDetails.sendtext);

            SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
            string Query = "Select * From Project Where Id='" + id + "'";

            SqlCommand cmd = new SqlCommand(Query, Constring);

            try
            {
                Constring.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    textBox1.Text = sdr["Project_Name"].ToString();
                    textBox2.Text = sdr["Location"].ToString();
                    textBox3.Text = sdr["Client_Name"].ToString();
                    textBox4.Text = sdr["Client_Number"].ToString();
                    textBox5.Text = sdr["PM_Name"].ToString();
                    textBox6.Text = sdr["Description"].ToString();
                    textBox7.Text = sdr["Budget"].ToString();
                }

            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProjectDetails projectDetails = new ProjectDetails();
            projectDetails.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
