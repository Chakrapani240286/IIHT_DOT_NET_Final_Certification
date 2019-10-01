using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.DataAccess.interfaces
{
    public interface IUser
    {
        User Create(User user);
        User Update(User user);
        string Delete(int userId);
        List<User> List();
    }
}
