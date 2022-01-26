using Dapper;
using ExpensesTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.DAO
{
    public class CategoryDAOImpl : ICategoryDAO
    {
        private IDbConnection conn;
        public CategoryDAOImpl()
        {
            conn = Controllers.DatabaseController.GetConnection();
        }

        public string Delete(int Id)
        {
            try
            {
                var affrow = conn.Execute(new CommandDefinition("DELETE FROM Categories WHERE Id = @Id", new { Id = Id}));
                if (affrow > 0)
                {
                    return "SUCCESS";
                }
                else
                {
                    return "Category Deleteion Failed.";
                }
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public List<Category> GetAll()
        {
            var Category = conn.Query<Category>(new CommandDefinition("SELECT * FROM Categories"));
            if (!Category.Any())
            {
                return new List<Category>();
            }
            else
            {
                return Category.ToList();
            }
        }

        public Category GetById(int id)
        {
            var Category = conn.Query<Category>(new CommandDefinition("SELECT * FROM Categories WHERE Id = @Id", new { Id = id }));
            if (!Category.Any())
            {
                return null;
            }
            else
            {
                return Category.First();
            }
        }

        public string Insert(Category c)
        {
            try
            {
                var affrow = conn.Execute(new CommandDefinition("INSERT INTO Categories (Name , CatType , UserId) VALUES(@Name , @CatType , @UserId)", new
                {
                    Name = c.GetName(),
                    CatType = c.GetCatType(),
                    UserId = Session.User.GetId()
                }));
                if (affrow > 0)
                {
                    return "SUCCESS";
                }
                else
                {
                    return "Category Creation Failed.";
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode == 19)
                {
                    return "Category Already Exists";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public List<Category> Search(string text)
        {
            var cmd = new CommandDefinition("SELECT * FROM Categories WHERE UserId = @UserId AND Name LIKE '%" + text + "%' OR CatType LIKE '%" + text + "%'", new
            {
                UserId = Session.User.GetId(),             
            });

            var Category = conn.Query<Category>(cmd);

            if (!Category.Any())
            {
                return new List<Category>();
            }
            else
            {
                return Category.ToList();
            }
        }

        public string Update(Category c)
        {
            try
            {
                var affrow = conn.Execute(new CommandDefinition("UPDATE Categories SET Name = @Name , CatType  = @CatType , UserId = @UserId WHERE Id = @Id", new
                {
                    Id = c.GetId(),
                    Name = c.GetName(),
                    CatType = c.GetCatType(),
                    UserId = Session.User.GetId()
                }));
                if (affrow > 0)
                {
                    return "SUCCESS";
                }
                else
                {
                    return "Category Update Failed.";
                }
            }
            catch (SQLiteException ex)
            {               
                return ex.Message;                
            }
        }
    }
}
