using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Construction.Expenses
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Visible = false;
            labelName.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string category = comboBox1.Text;
            string site = comboBox2.Text;
            string desc = textBox1.Text;
            double amount = double.Parse(textBox2.Text);

            DateTime date = DateTime.Today;
            DateTime time = DateTime.Now;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
            String query = "insert into Expenses values('" + category + "','" + site + "','" + desc + "','" + amount + "','" + date + "','" + time + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Inserted.");
                textBox1.Clear();
                textBox2.Clear();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
            string Query = "Select Project_Name From Project";
            SqlCommand cmd = new SqlCommand(Query, Constring);

            try
            {
                Constring.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("Project_Name", typeof(string));
                dt.Load(sdr);
                comboBox2.ValueMember = "Project_Name";
                comboBox2.DataSource = dt;
                textBox1.Clear();
                textBox2.Clear();
                Constring.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExpensesDetails expensesDetails = new ExpensesDetails();
            expensesDetails.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBox1.Text;
            if (category == "Site")
            {
                comboBox2.Visible = true;
                labelName.Visible = true;
            }
            else
            {
                comboBox2.ResetText();
                comboBox2.Visible = false;
                labelName.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }
    }
}
