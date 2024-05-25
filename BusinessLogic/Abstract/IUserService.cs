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
        Task<User> GetCurrentUser();
        void LogOut(User user);
        void Update(User user);
        Task<User> GetUserById(int id);
        void LogIn(User user);
        void UpdateUserStatus(int userId, bool isActive);
    }
}
