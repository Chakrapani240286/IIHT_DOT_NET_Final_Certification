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
    public class ProjectsController : ApiController
    {
        protected IUnityContainer container;
        public ProjectsController(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        [HttpGet]
        [Route("projects/list")]
        public IEnumerable<Projects> Get()
        {
            var Projects = container.Resolve<bProjects>();
            return Projects.List();
        }

        [HttpGet]
        [Route("projects/listbyuser")]
        public IEnumerable<Projects> GetByUser(int id)
        {
            var Projects = container.Resolve<bProjects>();
            return Projects.List().Where(m=>m.UserId==id).ToList();
        }

        [HttpGet]
        [Route("projects/listbymanager")]
        public IEnumerable<Projects> GetByManager(int id)
        {
            var Projects = container.Resolve<bProjects>();
            return Projects.List().Where(m => m.ManagerId == id).ToList();
        }

        [HttpGet]
        [Route("projects/byid")]
        public Projects DetailById(int id)
        {
            var Projects = container.Resolve<bProjects>();
            return Projects.List().Where(m => m.ProjectsId == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("projects/create")]
        public Projects Post([FromBody]Projects value)
        {
            bProjects abc = container.Resolve<bProjects>();
            value = abc.Create(value);
            return value;
        }

        [HttpDelete]
        [Route("projects/delete")]
        public int Delete(int id)
        {
            container.Resolve<bProjects>().Delete(id);
            return 100;
        }

        [HttpPut]
        [Route("projects/update")]
        public Projects Put(int id, [FromBody]Projects value)
        {
            bProjects abc = container.Resolve<bProjects>();
            value = abc.Update(value);
            return value;
        }
    }
}
