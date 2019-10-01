using Project.Manager.BusinessAccess;
using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace Project.Manager.Service.Controllers
{
    public class ProjectsTaskController : ApiController
    {
        protected IUnityContainer container;
        public ProjectsTaskController(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        [HttpGet]
        [Route("ProjectsTask/list")]
        public IEnumerable<ProjectsTask> Get()
        {
            var ProjectsTask = container.Resolve<bProjectsTask>();
            return ProjectsTask.List();
        }

        [HttpGet]
        [Route("ProjectsTask/byid")]
        public ProjectsTask DetailById(int id)
        {
            var ProjectsTask = container.Resolve<bProjectsTask>();
            return ProjectsTask.List().Where(m => m.ProjectsTaskId == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("ProjectsTask/create")]
        public ProjectsTask Post([FromBody]ProjectsTask value)
        {
            bProjectsTask abc = container.Resolve<bProjectsTask>();
            value = abc.Create(value);
            return value;
        }

        [HttpDelete]
        [Route("ProjectsTask/delete")]
        public int Delete(int id)
        {
            container.Resolve<bProjectsTask>().Delete(id);
            return 100;
        }

        [HttpPut]
        [Route("ProjectsTask/update")]
        public ProjectsTask Put(int id, [FromBody]ProjectsTask value)
        {
            bProjectsTask abc = container.Resolve<bProjectsTask>();
            value = abc.Update(value);
            return value;
        }
    }
}
