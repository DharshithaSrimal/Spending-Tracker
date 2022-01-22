using System;
using ExpensesTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using ExpensesTracker.Controllers;
using System.Data;

namespace ExpensesTracker.DAO
{
    public class UserDAOImpl : IUserDAO
    {
        private IDbConnection conn;
        public UserDAOImpl()
        {
            conn = DatabaseController.GetConnection();
        }
        public string AddUser(User u)
        {
            try
            {
                var affrow = conn.Execute(new CommandDefinition("INSERT INTO Users (Username , Password , UserType) VALUES(@Username , @Password , @UserType)", new
                {
                    Username = u.GetUsername(),
                    Password = u.GetPassword(),
                    UserType = u.GetUserType()
                }));
                if(affrow > 0 )
                {
                    return "SUCCESS";
                }
                else
                {
                    return "User Registration Failed.";
                }
            }
            catch (SQLiteException ex)
            {
                if(ex.ErrorCode == 19)
                {
                    return "User Already Exists";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public string DeleteUser(User u)
        {
            throw new NotImplementedException();
        }
        public string UpdateUser(User u)
        {
            throw new NotImplementedException();
        }

        public string Login(User u)
        {
           
            try
            {
                var Users = conn.Query<NormalUser>(new CommandDefinition("SELECT * FROM Users WHERE Username = @Username", new { Username = u.GetUsername() }));
                if (!Users.Any())
                {
                    return "User Doesnt Exists";
                }
                else
                {
                    if (Users.First().GetPassword() == u.GetPassword())
                    {
                        if (Users.First().GetUserType() == "ADMIN")
                        {
                            Session.User = new AdminUser();
                            Session.User.SetId(Users.First().GetId());
                            Session.User.SetUsername(Users.First().GetUsername());
                            Session.User.SetPassword(Users.First().GetPassword());
                            Session.User.SetUserType(Users.First().GetUserType());
                        }
                        else
                        {
                            Session.User = new NormalUser();
                            Session.User.SetId(Users.First().GetId());
                            Session.User.SetUsername(Users.First().GetUsername());
                            Session.User.SetPassword(Users.First().GetPassword());
                            Session.User.SetUserType(Users.First().GetUserType());
                        }
                        return "SUCCESS";
                    }
                    else
                    {
                        return "Invalid Credentials.";
                    }
                }
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }
}
