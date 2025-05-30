using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = LoginButton;
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passBox.Text;
            
            if (dbConn.AuthenticateUser(username, password))
            {
                MessageBox.Show("Log in successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPassBox_CheckedChanged(object sender, EventArgs e)
        {
            passBox.PasswordChar = showPassBox.Checked ? '\0' : '*';

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
