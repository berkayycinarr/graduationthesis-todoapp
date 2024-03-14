using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class UserDal : IUserDal
    {
        public void Add(User user)
        {
            using (DataContext context = new DataContext())
            {
                var addedEntity = context.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public async Task<User> GetByMail(string email)
        {
            using (DataContext context = new DataContext())
            {
                return await context.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
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
                return context.Set<User>().SingleOrDefault(p => p.Status == true);
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
    }
}
