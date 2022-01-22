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
        private DAO.IUserDAO userDAO;
        public LoginForm()
        {
            InitializeComponent();
            userDAO = new DAO.UserDAOImpl();
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
          
            if (String.IsNullOrEmpty(user.GetUsername()) || String.IsNullOrEmpty(user.GetPassword()))
            {
                MessageBox.Show("Username or Password Cannot be Empty.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else
            {
                var response = userDAO.Login(user);
                if (response == "SUCCESS")
                {
                    MessageBox.Show("Login Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Dashboard().Show();
                }
                else
                {
                    MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }                                                              
        }

        private void lnkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().Show();
        }
    }
}
