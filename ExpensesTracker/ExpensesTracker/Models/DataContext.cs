using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "ExpensesDB", ForeignKeys = true }.ConnectionString
        }, true)
        {
            
        }
    }
}
