using NUnit.Framework;
using Project.Manager.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.Test
{
    public class ProjectsTest
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["StoreServiceURL"].ToString());
        Projects ProjectsCreate;

        [SetUp]
        public void Init()
        {
            List<User> User;
            var request = new RestRequest("Projects/list", RestSharp.Method.GET);
            var response = client.Execute<List<User>>(request);
            User = response.Data;

            Random random = new Random();
            int num = random.Next(1, 1000);
            ProjectsCreate = new Projects()
            {
                Title = "NUNIT Project" + num,
                Description = "NUNIT Project" + num,
                Priority = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ManagerId = User.FirstOrDefault().UserId,
                UserId = User.FirstOrDefault().UserId,
                DateCreated = DateTime.Now
            };
        }

        [Test]
        public void CreateProjects_ShouldCreateProjects()
        {
            var postStoreRequest = new RestRequest("Projects/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsCreate);
            var responseCreated = client.Execute<Projects>(postStoreRequest);
            ProjectsCreate = responseCreated.Data;

            Assert.IsTrue(ProjectsCreate.ProjectsId > 0);
        }

        [Test]
        public void GetAllProjects_ShouldReturnAllProjects()
        {
            List<Projects> Projects;
            var request = new RestRequest("Projects/list", RestSharp.Method.GET);
            var response = client.Execute<List<Projects>>(request);
            Projects = response.Data;

            Assert.IsTrue(Projects.Count > 0);
        }

        [Test]
        public void GetProjectsById_ShouldGetProjectsById()
        {
            var postStoreRequest = new RestRequest("Projects/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsCreate);
            var responseCreated = client.Execute<Projects>(postStoreRequest);
            ProjectsCreate = responseCreated.Data;

            var request1 = new RestRequest("Projects/byid?id=" + ProjectsCreate.ProjectsId, Method.GET);
            var response1 = client.Execute<Projects>(request1);
            Projects Projects = response1.Data;

            Assert.AreEqual(ProjectsCreate.ProjectsId, Projects.ProjectsId);
        }

        [Test]
        public void CreateProjects_ShouldUpdateProjects()
        {
            string AfterCrtExpected = ProjectsCreate.Title;
            var postStoreRequest = new RestRequest("Projects/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsCreate);
            var responseCreated = client.Execute<Projects>(postStoreRequest);
            ProjectsCreate = responseCreated.Data;

            ProjectsCreate.Title = ProjectsCreate.Title + "updated";
            string AfterUpdtExpected = ProjectsCreate.Title;

            var postProjectsRequest = new RestRequest("Projects/update?id=" + ProjectsCreate.ProjectsId.ToString(), Method.PUT);
            postProjectsRequest.AddJsonBody(ProjectsCreate);
            var responseUpdated = client.Execute<Projects>(postProjectsRequest);
            ProjectsCreate = responseUpdated.Data;

            Assert.IsTrue(ProjectsCreate.ProjectsId > 0);
            Assert.AreEqual(AfterUpdtExpected, ProjectsCreate.Title);
        }

        [Test]
        public void CreateProjects_ShouldDeleteProjects()
        {
            var postStoreRequest = new RestRequest("Projects/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsCreate);
            var responseCreated = client.Execute<Projects>(postStoreRequest);
            ProjectsCreate = responseCreated.Data;

            var request = new RestRequest("Projects/delete?id=" + ProjectsCreate.ProjectsId, Method.DELETE);
            var response = client.Execute<int>(request);
            int deleteId = response.Data;

            Assert.AreEqual(100, deleteId);
        }
    }
}

