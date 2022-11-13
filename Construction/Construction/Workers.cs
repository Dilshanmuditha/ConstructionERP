using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Construction
{
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }

        private void Workers_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnWorkDetails_Click(object sender, EventArgs e)
        {
            WorkerDetails details = new WorkerDetails();
            details.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewWorker newWorker = new NewWorker();
            newWorker.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateWorkers updateWorkers = new UpdateWorkers();
            updateWorkers.Show();
            this.Close(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Workers_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxSalary_ReadOnlyChanged(object sender, EventArgs e)
        {
        }

        private void textBoxSalary_Enter(object sender, EventArgs e)
        {
            textBoxSalary.ReadOnly = true;

        }

        private void numericUpDownWorkDay_Enter(object sender, EventArgs e)
        {
           
        }

        private void numericUpDownWorkDay_Click(object sender, EventArgs e)
        {
            numericUpDownWorkDay.ResetText();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            double payDay = double.Parse(textBoxPay.Text);
            double workDays = double.Parse(numericUpDownWorkDay.Text);
            double ot = double.Parse(numericUpDownOt.Text);
            double allowance = double.Parse(textBoxAllowance.Text); 
            double expenses = double.Parse(textBoxExpenses.Text);
            

            double OtPay = (payDay/8)*ot;
            double salary = (payDay*workDays) + OtPay + allowance - expenses;

            textBoxSalary.Text = "Rs."+ salary;
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            string NIC = textBoxId.Text;
            if (NIC == "")
            {
                textBoxName.Text = "Please Enter Id Number";
                textBoxName.ForeColor = Color.Red;
            }
            else
            {
                int id = int.Parse(textBoxId.Text);
                SqlConnection Constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");
                string Query = "Select * From workerDetails Where Id='" + id + "'";
                //string a = "Id ='"+id + "'";
                SqlCommand cmd = new SqlCommand(Query, Constring);

                try
                {
                    Constring.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        textBoxName.Text = sdr["name"].ToString();
                        textBoxName.ForeColor = Color.Black;

                    }
                    else
                    {
                        textBoxName.Text = "*Not a Valid Id Number";
                        textBoxName.ForeColor = Color.Red;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(textBoxId.Text);
            string name = textBoxName.Text;
            double PayPerDay = double.Parse(textBoxPay.Text);
            double WorkDays = double.Parse(numericUpDownWorkDay.Text);
            double OtHours = double.Parse(numericUpDownOt.Text);
            double Allowance = double.Parse(textBoxAllowance.Text);
            double Expenses = double.Parse(textBoxExpenses.Text);
            DateTime date = DateTime.Today;
            DateTime time = DateTime.Now;
            

            double OtPay = (PayPerDay / 8) * OtHours;
            double Salary = (PayPerDay * WorkDays) + OtPay + Allowance - Expenses;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\AIC System Software\constructionDB.mdf"";Integrated Security=True;Connect Timeout=30");

            String query = "insert into Salary values('" + Id + "','" + name + "','" + PayPerDay + "','" + WorkDays + "','" + OtHours + "','" + Allowance + "','" + Expenses + "','" + Salary + "','"+ time +"','"+ date +"')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Inserted.");

                textBoxId.Clear();
                textBoxPay.Clear();
                textBoxName.Clear();
                textBoxSalary.Clear();
                textBoxExpenses.Clear();
                textBoxAllowance.Clear();
                numericUpDownOt.ResetText();
                numericUpDownWorkDay.ResetText();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalarySheet sheet = new SalarySheet();
            sheet.Show();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxPay.Clear();
            textBoxName.Clear();
            textBoxSalary.Clear();
            textBoxExpenses.Clear();
            textBoxAllowance.Clear();
            numericUpDownOt.ResetText();
            numericUpDownWorkDay.ResetText();
        }

        private void numericUpDownOt_Click(object sender, EventArgs e)
        {
            numericUpDownOt.ResetText();
        }
    }
}
