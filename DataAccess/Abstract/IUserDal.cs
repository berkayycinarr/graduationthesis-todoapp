using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        Task <User> GetByMail(string email);
        void Add(User user);
        void LogIn(User user);
        User GetCurrentUser();
        void LogOut(User user);
        void Update(User user);
        User GetUserById(int id);
    }
}
