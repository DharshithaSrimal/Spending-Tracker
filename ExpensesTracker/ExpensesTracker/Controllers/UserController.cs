using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Controllers
{
    public static class UserController
    {
        public static void getU()
        {
            var conn = DatabaseController.GetConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Users(Username , Password) VALUES ('amila2','1234')";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool Login(string username , string password)
        {
            return true;
        }
    }
}
