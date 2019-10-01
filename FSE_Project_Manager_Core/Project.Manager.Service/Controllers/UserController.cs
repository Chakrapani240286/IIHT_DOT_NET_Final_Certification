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
    public class UserController : ApiController
    {
        protected IUnityContainer container;
        public UserController(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
        [HttpGet]
        [Route("user/list")]
        public IEnumerable<User> Get()
        {
            var user = container.Resolve<bUser>();
            return user.List();
        }

        [HttpGet]
        [Route("user/byid")]
        public User DetailById(int id)
        {
            var user = container.Resolve<bUser>();
            return user.List().Where(m => m.UserId == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("user/byemail")]
        public User DetailByEmail(string emailid)
        {
            var user = container.Resolve<bUser>();
            return user.List().Where(m => m.EmailId == emailid).FirstOrDefault();
        }

        [HttpPost]
        [Route("user/create")]
        public User Post([FromBody]User value)
        {
            bUser abc = container.Resolve<bUser>();
            value = abc.Create(value);
            return value;
        }

        [HttpDelete]
        [Route("user/delete")]
        public int Delete(int id)
        {
            container.Resolve<bUser>().Delete(id);
            return 100;
        }

        [HttpPut]
        [Route("user/update")]
        public User Put(int id, [FromBody]User value)
        {
            bUser abc = container.Resolve<bUser>();
            value = abc.Update(value);
            return value;
        }
    }
}
