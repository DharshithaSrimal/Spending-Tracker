using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ExpensesTracker.Controllers
{
    public static class DatabaseController
    {
        private static SQLiteConnectionStringBuilder ConnectionStringBuilder;
        private static SQLiteConnection Connection;
        public static SQLiteConnection GetConnection()
        {
            if (Connection == null)
            {
                ConnectionStringBuilder = new SQLiteConnectionStringBuilder();               
                ConnectionStringBuilder.DataSource = "Database.db";              
                ConnectionStringBuilder.ForeignKeys = true;
                Connection = new SQLiteConnection(ConnectionStringBuilder.ConnectionString);
            }
            if(Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }
            return Connection;
        }
    }
}
