using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.DataAccess.interfaces
{
    public interface IProjectsTask
    {
        ProjectsTask Create(ProjectsTask ProjectTask);
        ProjectsTask Update(ProjectsTask ProjectTask);
        string Delete(int TaskId);
        List<ProjectsTask> List();
    }
}
