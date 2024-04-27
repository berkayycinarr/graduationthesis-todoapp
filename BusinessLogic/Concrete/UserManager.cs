using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void AddUser(User user)
        {
            _userDal.AddUser(user);
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.GetByMail(email);
        }

        public void LogIn(User user)
        {
            _userDal.LogIn(user);
        }
        public void LogOut(User user)
        {
            _userDal.LogOut(user);
        }

        public User GetCurrentUser()
        {
            return _userDal.GetCurrentUser();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public User GetUserById(int id)
        {
            return _userDal.GetUserById(id);
        }

    }
}

