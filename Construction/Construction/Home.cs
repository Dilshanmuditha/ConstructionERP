using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnWorkDetails_Click(object sender, EventArgs e)
        {
            Workers worker = new Workers();
            worker.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Expenses.Expenses expenses = new Expenses.Expenses();
            expenses.Show();
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Project.Projects project = new Project.Projects();
            project.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
