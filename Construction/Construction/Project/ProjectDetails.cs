using Construction.Expenses;
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

namespace Construction.Project
{
    public partial class ProjectDetails : Form
    {
        public ProjectDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM Project";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "Project");
            dataGridView1.DataSource = ds.Tables["Project"];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Project.Projects projects = new Project.Projects();
            projects.Show();
            this.Close();
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

            string delete = "DELETE FROM Project Where Id='" + id + "'";
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
                string Query = "Select * From Project Where Id='" + id + "'";

                SqlCommand cmd = new SqlCommand(Query, Constring);

                try
                {
                    Constring.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        sendtext = textBox1.Text;
                        UpdateProject update = new UpdateProject();
                        update.Show();
                        this.Close();
                    }
                    else
                    {
                        label2.Text = "*Not a Valid Id Number";
                        label2.ForeColor = Color.DarkOrange;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }

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
