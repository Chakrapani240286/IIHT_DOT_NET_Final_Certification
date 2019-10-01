using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.DataAccess.interfaces
{
    public interface IProjects
    {
        Projects Create(Projects Projects);
        Projects Update(Projects Projects);
        string Delete(int ProjectsId);
        List<Projects> List();
    }
}
