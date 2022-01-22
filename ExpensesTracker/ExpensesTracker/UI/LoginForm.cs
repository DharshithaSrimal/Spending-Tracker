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
            User u = new NormalUser();
            u.SetUsername("Baratha");
            u.SetPassword("0000");
            UserController.AddUser2(u);
            

       
        }
    }
}
