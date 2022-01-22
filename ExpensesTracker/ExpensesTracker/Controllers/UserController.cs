using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using ExpensesTracker.Models;
using Dapper;
using System.Data;
using Dapper.Contrib.Extensions;

namespace ExpensesTracker.Controllers
{
    public static class UserController
    {
        
        public static string AddUser(User u)
        {
            try
            {
                using (IDbConnection conn = DatabaseController.GetConnection())
                {
                    var affrows = conn.Execute(new CommandDefinition("INSERT INTO Users(Username , Password , UserType) VALUES(@Username , @Password , @UserType)", new
                    {
                        Username = u.GetUsername(),
                        Password = u.GetPassword(),
                        UserType = u.GetUserType(),
                    }));
                    if(affrows > 0) 
                    {
                        return "User Insert Success.";
                    }
                    else
                    {
                        return "User Insert Failed.";
                    }
                }
            }
            catch (SQLiteException ex)
            {
                if(ex.ErrorCode == 19)
                {
                    return "User Already Exists.";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string Login(User u)
        {
            try
            {
                using (IDbConnection conn = DatabaseController.GetConnection())
                {
                    var affrows = conn.Execute(new CommandDefinition("SELECT * FROM Users WHERE Username = @Username)",new {Username = u.GetUsername()}));
                    if (affrows > 0)
                    {
                        return "User Insert Success.";
                    }
                    else
                    {
                        return "User Insert Failed.";
                    }
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode == 19)
                {
                    return "User Already Exists.";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
    }
}
