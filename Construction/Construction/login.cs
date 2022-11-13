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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String uname = txtName.Text;
            String password = txtPassword.Text;
            if(uname != ""  && password != "")
            {
                if (uname == "aic" && password == "1965")
                {
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong User name or Password");
                }
            }
            else
            {
                MessageBox.Show("Can not input null values");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
