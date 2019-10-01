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
    public partial class projectdetail : System.Web.UI.Page
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Projects";
            if (Request.QueryString["Projectsid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnProjectsId.Value = Request.QueryString["Projectsid"].ToString();
                    int ProjectsId = Convert.ToInt32(Request.QueryString["Projectsid"].ToString());

                    var request = new RestRequest("user/list", Method.GET);
                    var response = client.Execute<List<User>>(request);
                    List<User> _UserList = response.Data;
                    foreach (var item in _UserList)
                    {
                        ddlManager.Items.Add(new ListItem { Text = item.EmailId, Value = item.UserId.ToString() });
                    }

                    for (int i = 1; i <= 10; i++)
                    {
                        ddlPriority.Items.Add(new ListItem { Text = i.ToString(), Value=i.ToString() });
                    }

                    var request1 = new RestRequest("Projects/byid?id=" + hdnProjectsId.Value, Method.GET);
                    var response1 = client.Execute<Projects>(request1);
                    Projects _Projects = response1.Data;

                    txtTitle.Text = _Projects.Title;
                    txtDescription.Text = _Projects.Description;
                    ddlPriority.SelectedValue = _Projects.Priority;
                    txtStartDate.Text = _Projects.StartDate.ToString("yyyy-MM-dd");
                    txtEndDate.Text = _Projects.EndDate.ToString("yyyy-MM-dd");
                    ddlManager.SelectedValue = _Projects.ManagerId.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ProjectsId = Convert.ToInt32(hdnProjectsId.Value);
            User user = (User)Session[ConfigurationManager.AppSettings["AdminSession"].ToString()];
            
            var request = new RestRequest("Projects/list", Method.GET);
            var response = client.Execute<List<Projects>>(request);
            List<Projects> _ProjectsList = response.Data;

            Projects _otherStr = _ProjectsList.Where(m => m.ProjectsId != ProjectsId && m.Title == txtTitle.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                
                var request1 = new RestRequest("Projects/byid?id=" + hdnProjectsId.Value, Method.GET);
                var response1 = client.Execute<Projects>(request1);
                Projects Projects = response1.Data;

                Projects.Title = txtTitle.Text.Trim();
                Projects.Description = txtDescription.Text;
                Projects.Priority = ddlPriority.Text;
                Projects.StartDate = Convert.ToDateTime(txtStartDate.Text);
                Projects.EndDate = Convert.ToDateTime(txtEndDate.Text);
                Projects.ManagerId = Convert.ToInt32(ddlManager.SelectedValue);
                Projects.UserId = user.UserId;
                Projects.DateCreated = DateTime.Now;

                //Update the Projects detail to database
                var postProjectsRequest = new RestRequest("Projects/update?id=" + hdnProjectsId.Value, Method.PUT);
                postProjectsRequest.AddJsonBody(Projects);
                var responseUpdated = client.Execute<Projects>(postProjectsRequest);
                Projects _adminUpdated = responseUpdated.Data;

                Response.Redirect("/administration/Projects.aspx?id=100&redirecturl=admin-Projects-rachna-teracotta");
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Projects detail not updated successfully, because Projects Email should not be same as other";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            var request = new RestRequest("Projects/delete?id=" + hdnProjectsId.Value, Method.DELETE);
            var response = client.Execute<int>(request);
            int deleteId = response.Data;

            if (deleteId == 100)
            {
                Response.Redirect("/administration/Projects.aspx?id=200&redirecturl=admin-Projects-rachna-teracotta");
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Failed! Unable to delete the selected Projects.";
            }
        }
    }
}