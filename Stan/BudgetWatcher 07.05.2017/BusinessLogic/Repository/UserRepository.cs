using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.DBContextDomain;
using System.Data.Entity;

namespace BusinessLogic.Repository
{
    public class UserRepository : IUserRepository
    {
        private User user = new User();

        public void Add(User item)
        {
            user.Email = item.Email;
            user.Password = item.Password;
            user.FirstName = item.FirstName;
            user.LastName = item.LastName;

            using (var context = new BudgetWatcherContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void Delete(User item)
        {
            user = GetById(item.Id);

            if (user == null)
            {
                throw new ArgumentNullException("Please choose existing user to delete");
            }

            using (var context = new BudgetWatcherContext())
            {
                context.Users.Attach(user);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public ICollection<User> GetAll()
        {
            ICollection<User> users = new HashSet<User>();
            using (var context = new BudgetWatcherContext())
            {
                users = context.Users.ToList();
            }
            return users;
        }

        public User GetById(int id)
        {
            using (var context = new BudgetWatcherContext())
            {
                user = context.Users.FirstOrDefault(x => x.Id == id);
            }

            if (user == null)
            {
                throw new ArgumentNullException("The user is not found");
            }

            return user;
        }

        public User GetUserByEmailAndPassword(string Email, string Password)
        {
            using (var context = new BudgetWatcherContext())
            {
                user = context.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);
            }

            if (user == null)
            {
                throw new ArgumentNullException("The user is not found");
            }

            return user;
        }

        public void Update(User item)
        {
            user = GetById(item.Id);

            if (user != null)
            {
                user.Email = item.Email;
                user.Password = item.Password;
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
            }
            else
            {
                throw new ArgumentNullException("The user is not found");
            }

            using (var context = new BudgetWatcherContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}