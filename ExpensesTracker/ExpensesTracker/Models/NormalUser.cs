using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Models
{
    public class NormalUser : User
    {
        public override int GetId()
        {
            return Id;
        }
        public override string GetUserType()
        {
            return UserType;
        }
        public override string GetPassword()
        {
            return Password;
        }
        public override string GetUsername()
        {
            return Username;
        }

        public override void SetId(int id)
        {
            this.Id = id;
        }
        public override void SetUserType(string userType)
        {
            this.UserType = userType;
        }
        public override void SetPassword(string password)
        {
            this.Password = password;
        }
        public override void SetUsername(string username)
        {
           this.Username = username;
        }

        public override string Login()
        {
            throw new NotImplementedException();
        }
        public override string Logout()
        {
            throw new NotImplementedException();
        }
    }
}
