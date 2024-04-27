using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IUserService
    {
        Task<User> GetByMail(string email);
        void AddUser(User user);
        void LogIn(User user);
        User GetCurrentUser();
        void LogOut(User user);
        void Update(User user);
        User GetUserById(int id);
    }
}
