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
    public class ProjectsTaskTest
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["StoreServiceURL"].ToString());
        ProjectsTask ProjectsTaskCreate;

        [SetUp]
        public void Init()
        {
            List<User> User;
            var request = new RestRequest("User/list", RestSharp.Method.GET);
            var response = client.Execute<List<User>>(request);
            User = response.Data;

            List<Projects> Projects;
            var requestProjects = new RestRequest("Projects/list", RestSharp.Method.GET);
            var responseProjects = client.Execute<List<Projects>>(requestProjects);
            Projects = responseProjects.Data;

            Random random = new Random();
            int num = random.Next(1, 1000);
            ProjectsTaskCreate = new ProjectsTask()
            {
                ProjectsId= Projects.FirstOrDefault().ProjectsId,
                Title = "NUNIT Project" + num,
                Description = "NUNIT Project" + num,
                Priority = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                TaskUserId = User.FirstOrDefault().UserId,
                UserId = User.FirstOrDefault().UserId,
                DateCreated = DateTime.Now
            };
        }

        [Test]
        public void CreateProjectsTask_ShouldCreateProjectsTask()
        {
            var postStoreRequest = new RestRequest("ProjectsTask/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsTaskCreate);
            var responseCreated = client.Execute<ProjectsTask>(postStoreRequest);
            ProjectsTaskCreate = responseCreated.Data;

            Assert.IsTrue(ProjectsTaskCreate.ProjectsTaskId > 0);
        }

        [Test]
        public void GetAllProjectsTask_ShouldReturnAllProjectsTask()
        {
            List<ProjectsTask> ProjectsTask;
            var request = new RestRequest("ProjectsTask/list", RestSharp.Method.GET);
            var response = client.Execute<List<ProjectsTask>>(request);
            ProjectsTask = response.Data;

            Assert.IsTrue(ProjectsTask.Count > 0);
        }

        [Test]
        public void GetProjectsTaskById_ShouldGetProjectsTaskById()
        {
            var postStoreRequest = new RestRequest("ProjectsTask/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsTaskCreate);
            var responseCreated = client.Execute<ProjectsTask>(postStoreRequest);
            ProjectsTaskCreate = responseCreated.Data;

            var request1 = new RestRequest("ProjectsTask/byid?id=" + ProjectsTaskCreate.ProjectsTaskId, Method.GET);
            var response1 = client.Execute<ProjectsTask>(request1);
            ProjectsTask ProjectsTask = response1.Data;

            Assert.AreEqual(ProjectsTaskCreate.ProjectsTaskId, ProjectsTask.ProjectsTaskId);
        }

        [Test]
        public void CreateProjectsTask_ShouldUpdateProjectsTask()
        {
            string AfterCrtExpected = ProjectsTaskCreate.Title;
            var postStoreRequest = new RestRequest("ProjectsTask/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsTaskCreate);
            var responseCreated = client.Execute<ProjectsTask>(postStoreRequest);
            ProjectsTaskCreate = responseCreated.Data;

            ProjectsTaskCreate.Title = ProjectsTaskCreate.Title + "updated";
            string AfterUpdtExpected = ProjectsTaskCreate.Title;

            var postProjectsTaskRequest = new RestRequest("ProjectsTask/update?id=" + ProjectsTaskCreate.ProjectsTaskId.ToString(), Method.PUT);
            postProjectsTaskRequest.AddJsonBody(ProjectsTaskCreate);
            var responseUpdated = client.Execute<ProjectsTask>(postProjectsTaskRequest);
            ProjectsTaskCreate = responseUpdated.Data;

            Assert.IsTrue(ProjectsTaskCreate.ProjectsTaskId > 0);
            Assert.AreEqual(AfterUpdtExpected, ProjectsTaskCreate.Title);
        }

        [Test]
        public void CreateProjectsTask_ShouldDeleteProjectsTask()
        {
            var postStoreRequest = new RestRequest("ProjectsTask/create", Method.POST);
            postStoreRequest.AddJsonBody(ProjectsTaskCreate);
            var responseCreated = client.Execute<ProjectsTask>(postStoreRequest);
            ProjectsTaskCreate = responseCreated.Data;

            var request = new RestRequest("ProjectsTask/delete?id=" + ProjectsTaskCreate.ProjectsTaskId, Method.DELETE);
            var response = client.Execute<int>(request);
            int deleteId = response.Data;

            Assert.AreEqual(100, deleteId);
        }
    }
}

