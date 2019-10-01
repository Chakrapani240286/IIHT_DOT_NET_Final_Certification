using Project.Manager.DataAccess.interfaces;
using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.BusinessAccess
{
    public class bProjectsTask
    {
        IProjectsTask _ProjectsTask;
        public bProjectsTask(IProjectsTask ProjectsTask)
        {
            _ProjectsTask = ProjectsTask;
        }

        public ProjectsTask Create(ProjectsTask ProjectsTask)
        {
            return _ProjectsTask.Create(ProjectsTask);
        }

        public string Delete(int ProjectsTaskId)
        {
            return _ProjectsTask.Delete(ProjectsTaskId);
        }

        public List<ProjectsTask> List()
        {
            return _ProjectsTask.List();
        }

        public ProjectsTask Update(ProjectsTask ProjectsTask)
        {
            return _ProjectsTask.Update(ProjectsTask);
        }
    }
}
