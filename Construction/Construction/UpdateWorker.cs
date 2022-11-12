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
    public partial class NewWorker : Form
    {
        public NewWorker()
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
            String name = textBox1.Text;
            int id = int.Parse(textBox2.Text);
            String address = textBox3.Text;
            String dob = textBox4.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");

            String query = "insert into workerDetails values('" + id + "','" + name + "','" + address + "','" + dob + "')";
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
        }
    }
}
