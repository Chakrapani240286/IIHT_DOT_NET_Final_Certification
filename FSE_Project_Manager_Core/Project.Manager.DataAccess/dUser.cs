using Project.Manager.DataAccess.App_Data;
using Project.Manager.DataAccess.Helper;
using Project.Manager.DataAccess.interfaces;
using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.DataAccess
{
    public class dUser : IUser
    {
        private PMDBContext context;
        public dUser()
        {
            context = new PMDBContext();
        }

        public User Create(User user)
        {
            user.Password = PasswordProtect.Encrypt(user.Password);
            context.User.Add(user);
            context.SaveChanges();
            return user;
        }

        public string Delete(int userId)
        {
            User User = context.User.Where(m => m.UserId == userId).FirstOrDefault();
            context.Entry(User).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            return "Success";
        }

        public List<User> List()
        {
            return context.User.ToList();
        }

        public User Update(User user)
        {
            var entity = context.User.Where(c => c.UserId == user.UserId).AsQueryable().FirstOrDefault();
            if (entity == null)
            {
                user.Password = PasswordProtect.Encrypt(user.Password);
                context.User.Add(user);
            }
            else
            {
                user.Password = PasswordProtect.Encrypt(user.Password);
                context.Entry(entity).CurrentValues.SetValues(user);
            }
            context.SaveChanges();
            return user;
        }
    }
}
