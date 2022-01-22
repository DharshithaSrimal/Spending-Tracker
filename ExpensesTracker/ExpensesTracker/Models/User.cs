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
    public abstract class User
    {
        protected  int Id;
        protected  string Username;
        protected  string Password;
        protected  string UserType;

        public abstract int GetId();
        public abstract string GetUsername();
        public abstract string GetPassword();
        public abstract string GetUserType();

        public abstract void SetId(int id);
        public abstract void SetUsername(string username);
        public abstract void SetPassword(string password);
        public abstract void SetUserType(string isadmin);

        

    }
}
