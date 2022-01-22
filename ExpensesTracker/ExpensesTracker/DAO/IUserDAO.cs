using ExpensesTracker.Models;

namespace ExpensesTracker.DAO
{
    public interface IUserDAO
    {
        string AddUser(User u);
        string UpdateUser(User u);
        string DeleteUser(User u);
        string Login(User u);
    }
}
