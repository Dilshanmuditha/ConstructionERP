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
    public partial class WorkerDetails : Form
    {
        public WorkerDetails()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Workers worker = new Workers();
            worker.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM workerDetails";

            SqlDataAdapter adapter = new SqlDataAdapter(Query,Constring);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "workerDetails");
            dataGridView1.DataSource = ds.Tables["workerDetails"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM workerDetails WHERE Id='" + id + "'";
            try {
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Constring);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "workerDetails");
                dataGridView1.DataSource = ds.Tables["workerDetails"];
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");

            string delete = "DELETE FROM workerDetails Where Id='" + id + "'";
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

        private void WorkerDetails_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
