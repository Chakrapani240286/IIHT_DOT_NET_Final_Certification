using Project.Manager.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Manager.Web.administration
{
    public partial class users : System.Web.UI.Page
    {
        RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : User";

                if (Request.QueryString["id"] != null)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Ohoo!!! User Detail Updated Successfully";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var request = new RestRequest("user/list", Method.GET);
            var response = client.Execute<List<User>>(request);
            User User1 = response.Data.Where(m => m.EmailId == txtEmailId.Text.Trim()).FirstOrDefault();

            if (User1 == null)
            {
                User UserCreate = new User()
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text,
                    EmailId = txtEmailId.Text,
                    Password = "admin",
                    Status = "Active",
                    DateCreated = DateTime.Now,
                };

                var postStoreRequest = new RestRequest("user/create", Method.POST);
                postStoreRequest.AddJsonBody(UserCreate);
                var responseCreated = client.Execute<User>(postStoreRequest);
                UserCreate = responseCreated.Data;

                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "User created Successfully";
                ClearFields();

            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! User Creation failed, Name already exists";
            }
        }

        private void ClearFields()
        {
            txtEmailId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
        }
    }
}