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

namespace Construction.Expenses
{
    public partial class ExpensesDetails : Form
    {
        public ExpensesDetails()
        {
            InitializeComponent();
        }

        private void ExpensesDetails_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label2.Visible = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBox1.Text;
            if (category == "Site")
            {
                comboBox2.Visible = true;
                label2.Visible = true;
            }
            else
            {
                comboBox2.Visible=false;
                label2.Visible=false;
            }
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
                Constring.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string category = comboBox1.Text;
           
            if (category == "Site")
            {
                string site = comboBox2.Text;
                string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
                string Query = "SELECT * FROM Expenses WHERE category = 'Site' AND Site_Name = '"+site+"'";
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "Expenses");
                    dataGridView1.DataSource = ds.Tables["Expenses"];
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }
            else if (category == "Company")
            {
                string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
                string Query = "SELECT * FROM Expenses WHERE category ='Company'";
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "Expenses");
                    dataGridView1.DataSource = ds.Tables["Expenses"];
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }

            else
            {
                string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
                string Query = "SELECT * FROM Expenses WHERE category ='Personal'";
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "Expenses");
                    dataGridView1.DataSource = ds.Tables["Expenses"];
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter ID Number")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter ID Number";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");

            string delete = "DELETE FROM Expenses Where Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(delete, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Deleted.");

            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Expenses expenses = new Expenses();
            expenses.Show();
            this.Close();
        }
        public static string sendtext = "";
        private void button4_Click(object sender, EventArgs e)
        {
            
            string NIC = textBox1.Text;
            if (NIC == "")
            {
                label3.Text = "please enter id number";
            }
            else
            {
                int id = int.Parse(textBox1.Text);

                SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
                string Query = "Select * From Expenses Where Id='" + id + "'";

                SqlCommand cmd = new SqlCommand(Query, Constring);

                try
                {
                    Constring.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        sendtext = textBox1.Text; 
                        UpdateExpenses update = new UpdateExpenses();
                        update.Show();
                        this.Close();
                    }
                    else
                    {
                        label3.Text = "*Not a Valid Id Number";
                        label3.ForeColor = Color.DarkOrange;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM Expenses";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "Expenses");
                dataGridView1.DataSource = ds.Tables["Expenses"];
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataObject copydata = dataGridView1.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

        }
    }
}
