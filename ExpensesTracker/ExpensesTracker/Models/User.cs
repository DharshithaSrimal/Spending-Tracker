using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Dapper;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public bool Login()
        {
            if(String.IsNullOrEmpty(Username) || (string.IsNullOrEmpty(Password)))
            {
                MessageBox.Show("Username or Password Cannot be null or Empty" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }




    }
}
