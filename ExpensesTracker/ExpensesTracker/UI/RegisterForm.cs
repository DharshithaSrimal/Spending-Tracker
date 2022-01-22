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

namespace ExpensesTracker.UI
{
    public partial class RegisterForm : Form
    {
        private DAO.IUserDAO userDAO;
        public RegisterForm()
        {
            userDAO = new DAO.UserDAOImpl();
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear(); 
            txtConfirmPassword.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Username or Passwords Cannot be Empty." , "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else
            {
                if(txtConfirmPassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Password and Confirm Password Doesnt Match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                    txtPassword.Focus();
                }
                else
                {
                    User u = new NormalUser();
                    u.SetUsername(txtUsername.Text);
                    u.SetPassword(txtPassword.Text);
                    var response = userDAO.AddUser(u);
                    if(response == "SUCCESS")
                    {
                        MessageBox.Show("User Register Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    btnClear.PerformClick();
                }
            }
        }
    }
}
