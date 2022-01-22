using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Models
{
    public class Category
    {
        private int Id;
        private string Name;
        private string CatType;
        private int UserId;

        public int GetId() { return Id; }
        public string GetName() { return Name; } 
        public string GetCatType() { return CatType; }
        public int GetUserId(){ return UserId; }
        public void SetName(string name) { Name = name; }
        public void SetCatType(String catType) { CatType = catType; }
    }
}
