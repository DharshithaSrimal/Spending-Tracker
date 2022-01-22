using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpensesTracker.Models;
using ExpensesTracker.Controllers;

namespace ExpensesTracker.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char) Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new NormalUser();
            user.SetUsername(txtUsername.Text);
            user.SetPassword(txtPassword.Text);   
            
            Controllers.UserController userController = new Controllers.UserController();
            
            var response = userController.Login(user);
            if (response == "SUCCESS")
            {
                MessageBox.Show("Login Success.", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                new Dashboard().Show();
            }
            else
            {
                MessageBox.Show( response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
       
        }
    }
}
