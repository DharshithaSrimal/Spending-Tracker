using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Models
{
    public class AdminUser : User
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
            return Controllers.UserController.Login(this);
        }
        public override string Logout()
        {
            throw new NotImplementedException();
        }
        
        //Methods Unique only to admins
        public bool RemoveUser()
        {
            throw new NotImplementedException();
        }

        public bool GetUser()
        {
            throw new NotImplementedException();
        }

        public bool GetAllUsers()
        {
            throw new NotImplementedException();
        }
        public string AddUser(User u)
        {
            return Controllers.UserController.AddUser(u);
        }

        public AdminUser()
        {
            UserType = "ADMIN";
        }

    }
}
