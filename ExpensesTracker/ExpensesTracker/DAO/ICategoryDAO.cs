using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesTracker.Models;

namespace ExpensesTracker.DAO
{
    public interface ICategoryDAO
    {
        string Insert(Category c);
        string Update(Category c);
        string Delete(Category c);
        Category GetById(int Id);
        List<Category> GetAll();
    }
}
