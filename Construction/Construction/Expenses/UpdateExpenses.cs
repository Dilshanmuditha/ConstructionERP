using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Construction.Expenses
{
    public partial class UpdateExpenses : Form
    {
        public UpdateExpenses()
        {
            InitializeComponent();
        }

        private void UpdateExpenses_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            labelName.Visible = false;

            int id = int.Parse(ExpensesDetails.sendtext);

            SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
            string Query = "Select * From Expenses Where Id='" + id + "'";

            SqlCommand cmd = new SqlCommand(Query, Constring);

            try
            {
                Constring.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    textBox1.Text = sdr["Description"].ToString();
                    textBox2.Text = sdr["Amount"].ToString();
                }
                
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExpensesDetails expensesDetails = new ExpensesDetails();
            expensesDetails.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ExpensesDetails.sendtext);
            string category = comboBox1.Text;
            string site = comboBox2.Text;
            string desc = textBox1.Text;
            double amount = double.Parse(textBox2.Text);

            DateTime date = DateTime.Today;
            DateTime time = DateTime.Now;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
            string update = "UPDATE Expenses SET category= '" + category + "',Site_Name='" + site + "',Description='" + desc + "',Amount='" + amount + "',date='" + date + "',time='" + time + "' WHERE Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(update, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Updated.");
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void comboBox2_Enter_1(object sender, EventArgs e)
        {
            SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
            string Query = "Select Project_Name From Project";
            SqlCommand cmd = new SqlCommand(Query, Constring);

            try
            {
                Constring.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("Project_Name", typeof(string));
                dt.Load(sdr);
                comboBox2.ValueMember = "Project_Name";
                comboBox2.DataSource = dt;
                Constring.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
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
                comboBox2.Visible = false;
                labelName.Visible = false;
            }
        }
    }
}
