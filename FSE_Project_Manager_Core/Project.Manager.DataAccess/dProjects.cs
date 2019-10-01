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
    public class dProjects : IProjects
    {
        private PMDBContext context;
        public dProjects()
        {
            context = new PMDBContext();
        }

        public Projects Create(Projects Projects)
        {
            context.Projects.Add(Projects);
            context.SaveChanges();
            return Projects;
        }

        public string Delete(int ProjectsId)
        {
            Projects Projects = context.Projects.Where(m => m.ProjectsId == ProjectsId).FirstOrDefault();
            context.Entry(Projects).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            return "Success";
        }

        public List<Projects> List()
        {
            return context.Projects.ToList();
        }

        public Projects Update(Projects Projects)
        {
            var entity = context.Projects.Where(c => c.ProjectsId == Projects.ProjectsId).AsQueryable().FirstOrDefault();
            if (entity == null)
            {
                context.Projects.Add(Projects);
            }
            else
            {
                context.Entry(entity).CurrentValues.SetValues(Projects);
            }
            context.SaveChanges();
            return Projects;
        }
    }
}
