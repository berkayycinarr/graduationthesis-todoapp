using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class UserDal : IUserDal
    {
        public void AddUser(User user)
        {
            using (DataContext context = new DataContext())
            {
                var addedEntity = context.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public User GetByMail(string email)
        {
            using (DataContext context = new DataContext())
            {
                return context.Users.Where(x => x.EmailAddress == email).FirstOrDefault();
            }
        }

        public User GetUserById(int id)
        {
            using (DataContext context = new DataContext())
            {
                return context.Users.FirstOrDefault(x => x.Id == id);
            }
        }


        public User GetCurrentUser()
        {
            using (DataContext context = new DataContext())
            {
                return context.Set<User>().SingleOrDefault(p => p.IsActive == true);
            }
        }

        public void LogIn(User user)
        {
            using (DataContext context = new DataContext())
            {
                var updatedEntry = context.Entry(user);
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void LogOut(User user)
        {
            using (DataContext context = new DataContext())
            {
                var updatedEntry = context.Entry(user);
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (DataContext context = new DataContext())
            {
                var updatedEntry = context.Entry(user);
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateUserStatus(int userId, bool isActive)
        {
            using (DataContext context = new DataContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsActive = isActive;
                    context.SaveChanges();
                }
            }
        }

    }
}
