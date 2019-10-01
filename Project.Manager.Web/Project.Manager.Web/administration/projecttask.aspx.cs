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
    public partial class projecttask : System.Web.UI.Page
    {
        RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Projects";

                var request = new RestRequest("projects/list", Method.GET);
                var response = client.Execute<List<Projects>>(request);
                List<Projects> _ProjectsList = response.Data;
                foreach (var item in _ProjectsList)
                {
                    ddlProject.Items.Add(new ListItem { Text = item.Title, Value = item.ProjectsId.ToString() });
                }

                var request1 = new RestRequest("user/list", Method.GET);
                var response1 = client.Execute<List<User>>(request1);
                List<User> _UserList = response1.Data;
                foreach (var item in _UserList)
                {
                    ddlManager.Items.Add(new ListItem { Text = item.EmailId, Value = item.UserId.ToString() });
                }

                for (int i = 1; i <= 10; i++)
                {
                    ddlPriority.Items.Add(new ListItem { Text = i.ToString() });
                }

                if (Request.QueryString["id"] != null)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Ohoo!!! Projects Detail Updated Successfully";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            User user = (User)Session[ConfigurationManager.AppSettings["AdminSession"].ToString()];
            var request = new RestRequest("ProjectsTask/list", Method.GET);
            var response = client.Execute<List<ProjectsTask>>(request);
            ProjectsTask Projects1 = response.Data.Where(m => m.Title == txtTitle.Text.Trim()).FirstOrDefault();

            if (Projects1 == null)
            {
                ProjectsTask ProjectsCreate = new ProjectsTask()
                {
                   ProjectsId= Convert.ToInt32(ddlProject.SelectedValue),
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text,
                    Priority = ddlPriority.Text,
                    StartDate = Convert.ToDateTime(txtStartDate.Text),
                    EndDate = Convert.ToDateTime(txtEndDate.Text),
                    TaskUserId = Convert.ToInt32(ddlManager.SelectedValue),
                    UserId = user.UserId,
                    DateCreated = DateTime.Now
                };

                var postStoreRequest = new RestRequest("ProjectsTask/create", Method.POST);
                postStoreRequest.AddJsonBody(ProjectsCreate);
                var responseCreated = client.Execute<ProjectsTask>(postStoreRequest);
                ProjectsCreate = responseCreated.Data;

                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "ProjectsTask created Successfully";
                ClearFields();

            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! ProjectsTask Creation failed, Name already exists";
            }
        }

        private void ClearFields()
        {
            ddlProject.Text = "Select...";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            ddlManager.Text = "Select...";
            ddlPriority.Text = "Select...";
        }
    }
}