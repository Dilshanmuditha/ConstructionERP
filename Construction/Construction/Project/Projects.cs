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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Construction.Project
{
    public partial class Projects : Form
    {
        public Projects()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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

            String query = "insert into Project values('" + name + "','" + location + "','" + clientName + "','" + clientNumber + "','" + pmName + "','" + desc + "','" + budget+"','" + date + "','" + time + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Inserted.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            Project.ProjectDetails projectDetails = new Project.ProjectDetails();
            projectDetails.Show();
            this.Close();
        }

        private void Projects_Load(object sender, EventArgs e)
        {

        }
    }
}
