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
    public class UsersTest
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["StoreServiceURL"].ToString());
        User UserCreate;

        [SetUp]
        public void Init()
        {
            Random random = new Random();
            int num = random.Next(1, 1000);
            UserCreate = new User()
            {
                FirstName = "NUnit" + num,
                LastName = "Testing" + num,
                EmailId = "NU" + num + "@fse.com",
                Password = "admin",
                Status = "Active",
                DateCreated = DateTime.Now,
            };
        }

        [Test]
        public void CreateUser_ShouldCreateUser()
        {
            var postStoreRequest = new RestRequest("user/create", Method.POST);
            postStoreRequest.AddJsonBody(UserCreate);
            var responseCreated = client.Execute<User>(postStoreRequest);
            UserCreate = responseCreated.Data;

            Assert.IsTrue(UserCreate.UserId > 0);
        }

        [Test]
        public void GetAllUser_ShouldReturnAllUser()
        {
            List<User> User;
            var request = new RestRequest("user/list", RestSharp.Method.GET);
            var response = client.Execute<List<User>>(request);
            User = response.Data;

            Assert.IsTrue(User.Count > 0);
        }

        [Test]
        public void GetUserById_ShouldGetUserById()
        {
            string AfterCrtExpected = UserCreate.FirstName;
            var postStoreRequest = new RestRequest("user/create", Method.POST);
            postStoreRequest.AddJsonBody(UserCreate);
            var responseCreated = client.Execute<User>(postStoreRequest);
            UserCreate = responseCreated.Data;

            var request1 = new RestRequest("user/byid?id=" + UserCreate.UserId, Method.GET);
            var response1 = client.Execute<User>(request1);
            User User = response1.Data;

            Assert.AreEqual(UserCreate.UserId, User.UserId);
        }

        [Test]
        public void GetUserByEmail_ShouldGetUserByEmail()
        {
            string AfterCrtExpected = UserCreate.FirstName;
            var postStoreRequest = new RestRequest("user/create", Method.POST);
            postStoreRequest.AddJsonBody(UserCreate);
            var responseCreated = client.Execute<User>(postStoreRequest);
            UserCreate = responseCreated.Data;

            var request1 = new RestRequest("user/byemail?emailid=" + UserCreate.EmailId, Method.GET);
            var response1 = client.Execute<User>(request1);
            User User = response1.Data;

            Assert.AreEqual(UserCreate.UserId, User.UserId);
        }

        [Test]
        public void CreateUser_ShouldUpdateUser()
        {
            string AfterCrtExpected = UserCreate.FirstName;
            var postStoreRequest = new RestRequest("user/create", Method.POST);
            postStoreRequest.AddJsonBody(UserCreate);
            var responseCreated = client.Execute<User>(postStoreRequest);
            UserCreate = responseCreated.Data;

            UserCreate.FirstName = UserCreate.FirstName + "updated";
            string AfterUpdtExpected = UserCreate.FirstName;

            var postUserRequest = new RestRequest("user/update?id=" + UserCreate.UserId.ToString(), Method.PUT);
            postUserRequest.AddJsonBody(UserCreate);
            var responseUpdated = client.Execute<User>(postUserRequest);
            UserCreate = responseUpdated.Data;

            Assert.IsTrue(UserCreate.UserId > 0);
            Assert.AreEqual(AfterUpdtExpected, UserCreate.FirstName);
        }

        [Test]
        public void CreateUser_ShouldDeleteUser()
        {
            string AfterCrtExpected = UserCreate.FirstName;
            var postStoreRequest = new RestRequest("user/create", Method.POST);
            postStoreRequest.AddJsonBody(UserCreate);
            var responseCreated = client.Execute<User>(postStoreRequest);
            UserCreate = responseCreated.Data;

            var request = new RestRequest("user/delete?id=" + UserCreate.UserId, Method.DELETE);
            var response = client.Execute<int>(request);
            int deleteId = response.Data;

            Assert.AreEqual(100, deleteId);
        }
    }
}

