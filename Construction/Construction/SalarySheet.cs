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

namespace Construction
{
    public partial class SalarySheet : Form
    {
        public SalarySheet()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Workers workers = new Workers();
            workers.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM Salary";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "Salary");
            dataGridViewSalary.DataSource = ds.Tables["Salary"];
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Enter ID Number")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.Black;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            {
                textBoxSearch.Text = "Enter ID Number";
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxSearch.Text);
            string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM Salary WHERE Id='" + id + "'";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "Salary");
                dataGridViewSalary.DataSource = ds.Tables["Salary"];
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DataObject copydata = dataGridViewSalary.GetClipboardContent();
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
