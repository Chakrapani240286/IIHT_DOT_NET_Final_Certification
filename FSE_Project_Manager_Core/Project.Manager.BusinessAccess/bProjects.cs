using Project.Manager.DataAccess.interfaces;
using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.BusinessAccess
{
    public class bProjects
    {
        IProjects _Projects;
        public bProjects(IProjects Projects)
        {
            _Projects = Projects;
        }

        public Projects Create(Projects Projects)
        {
            return _Projects.Create(Projects);
        }

        public string Delete(int ProjectsId)
        {
            return _Projects.Delete(ProjectsId);
        }

        public List<Projects> List()
        {
            return _Projects.List();
        }

        public Projects Update(Projects Projects)
        {
            return _Projects.Update(Projects);
        }
    }
}
