using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SQLite;
using ExpensesTracker.Models;
using Dapper;
using System.Data;
using ExpensesTracker.Controllers;

namespace ExpensesTracker.DAO
{
    public class UserDAO
    {
        public string Login(User u)
        {
            IDbConnection conn = DatabaseController.GetConnection();
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
