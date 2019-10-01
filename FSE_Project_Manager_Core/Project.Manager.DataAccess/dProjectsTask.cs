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
    public class dProjectsTask : IProjectsTask
    {
        private PMDBContext context;
        public dProjectsTask()
        {
            context = new PMDBContext();
        }

        public ProjectsTask Create(ProjectsTask ProjectsTask)
        {
            context.ProjectsTask.Add(ProjectsTask);
            context.SaveChanges();
            return ProjectsTask;
        }

        public string Delete(int ProjectsTaskId)
        {
            ProjectsTask ProjectsTask = context.ProjectsTask.Where(m => m.ProjectsTaskId == ProjectsTaskId).FirstOrDefault();
            context.Entry(ProjectsTask).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            return "Success";
        }

        public List<ProjectsTask> List()
        {
            return context.ProjectsTask.Include("Projects").ToList();
        }

        public ProjectsTask Update(ProjectsTask ProjectsTask)
        {
            var entity = context.ProjectsTask.Where(c => c.ProjectsTaskId == ProjectsTask.ProjectsTaskId).AsQueryable().FirstOrDefault();
            if (entity == null)
            {
                context.ProjectsTask.Add(ProjectsTask);
            }
            else
            {
                context.Entry(entity).CurrentValues.SetValues(ProjectsTask);
            }
            context.SaveChanges();
            return ProjectsTask;
        }
    }
}
