using Project.Manager.DataAccess.interfaces;
using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.BusinessAccess
{
    public class bUser
    {
        IUser _user;
        public bUser(IUser user)
        {
            _user = user;
        }

        public User Create(User user)
        {
            return _user.Create(user);
        }

        public string Delete(int userId)
        {
            return _user.Delete(userId);
        }

        public List<User> List()
        {
            return _user.List();
        }

        public User Update(User user)
        {
            return _user.Update(user);
        }
    }
}
