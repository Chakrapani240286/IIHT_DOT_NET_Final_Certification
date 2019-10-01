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
    public partial class projecttaskdetail : System.Web.UI.Page
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Projects";
            if (Request.QueryString["ProjectsTaskId"] != null)
            {
                if (!IsPostBack)
                {
                    hdnProjectTaskId.Value = Request.QueryString["ProjectsTaskId"].ToString();
                    int ProjectsTaskId = Convert.ToInt32(Request.QueryString["ProjectsTaskId"].ToString());

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
                        ddlPriority.Items.Add(new ListItem { Text = i.ToString(), Value = i.ToString() });
                    }

                    var request12 = new RestRequest("projectstask/byid?id=" + hdnProjectTaskId.Value, Method.GET);
                    var response12 = client.Execute<ProjectsTask>(request12);
                    ProjectsTask _ProjectsTask = response12.Data;

                    txtTitle.Text = _ProjectsTask.Title;
                    txtDescription.Text = _ProjectsTask.Description;
                    ddlPriority.SelectedValue = _ProjectsTask.Priority;
                    txtStartDate.Text = _ProjectsTask.StartDate.ToString("yyyy-MM-dd");
                    txtEndDate.Text = _ProjectsTask.EndDate.ToString("yyyy-MM-dd");
                    ddlManager.SelectedValue = _ProjectsTask.TaskUserId.ToString();
                    ddlProject.SelectedValue = _ProjectsTask.ProjectsId.ToString();
                    lblBcTitle.Text = _ProjectsTask.Title;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ProjectsTaskId = Convert.ToInt32(hdnProjectTaskId.Value);
            User user = (User)Session[ConfigurationManager.AppSettings["AdminSession"].ToString()];

            var request = new RestRequest("ProjectsTask/list", Method.GET);
            var response = client.Execute<List<ProjectsTask>>(request);
            List<ProjectsTask> _ProjectsTaskList = response.Data;

            ProjectsTask _otherStr = _ProjectsTaskList.Where(m => m.ProjectsTaskId != ProjectsTaskId && m.Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {

                var request1 = new RestRequest("ProjectsTask/byid?id=" + hdnProjectTaskId.Value, Method.GET);
                var response1 = client.Execute<ProjectsTask>(request1);
                ProjectsTask ProjectsTask = response1.Data;

                ProjectsTask.ProjectsId = Convert.ToInt32(ddlProject.SelectedValue);
                ProjectsTask.Title = txtTitle.Text.Trim();
                ProjectsTask.Description = txtDescription.Text;
                ProjectsTask.Priority = ddlPriority.Text;
                ProjectsTask.StartDate = Convert.ToDateTime(txtStartDate.Text);
                ProjectsTask.EndDate = Convert.ToDateTime(txtEndDate.Text);
                ProjectsTask.TaskUserId = Convert.ToInt32(ddlManager.SelectedValue);
                ProjectsTask.UserId = user.UserId;
                ProjectsTask.DateCreated = DateTime.Now;

                //Update the ProjectsTask detail to database
                var postProjectsTaskRequest = new RestRequest("ProjectsTask/update?id=" + hdnProjectTaskId.Value, Method.PUT);
                postProjectsTaskRequest.AddJsonBody(ProjectsTask);
                var responseUpdated = client.Execute<ProjectsTask>(postProjectsTaskRequest);
                ProjectsTask _adminUpdated = responseUpdated.Data;

                Response.Redirect("/administration/ProjectTask.aspx?id=100&redirecturl=admin-ProjectsTask-rachna-teracotta");
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! ProjectsTask detail not updated successfully, because ProjectsTask Email should not be same as other";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            var request = new RestRequest("ProjectsTask/delete?id=" + hdnProjectTaskId.Value, Method.DELETE);
            var response = client.Execute<int>(request);
            int deleteId = response.Data;

            if (deleteId == 100)
            {
                Response.Redirect("/administration/ProjectTask.aspx?id=200&redirecturl=admin-ProjectsTask-rachna-teracotta");
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Failed! Unable to delete the selected ProjectsTask.";
            }
        }
    }
}