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
    public partial class projects : System.Web.UI.Page
    {
        RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Projects";

                
                var request = new RestRequest("user/list", Method.GET);
                var response = client.Execute<List<User>>(request);
                List<User> _UserList = response.Data;
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
            var request = new RestRequest("Projects/list", Method.GET);
            var response = client.Execute<List<Projects>>(request);
            Projects Projects1 = response.Data.Where(m => m.Title == txtTitle.Text.Trim()).FirstOrDefault();

            if (Projects1 == null)
            {
                Projects ProjectsCreate = new Projects()
                {
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text,
                    Priority = ddlPriority.Text,
                    StartDate = (chkStartEnddate.Checked == true) ? Convert.ToDateTime(txtStartDate.Text) : DateTime.Now,
                    EndDate = (chkStartEnddate.Checked == true) ? Convert.ToDateTime(txtEndDate.Text) : DateTime.Now,
                    ManagerId = Convert.ToInt32(ddlManager.SelectedValue),
                    UserId = user.UserId,
                    DateCreated = DateTime.Now
                };

                var postStoreRequest = new RestRequest("Projects/create", Method.POST);
                postStoreRequest.AddJsonBody(ProjectsCreate);
                var responseCreated = client.Execute<Projects>(postStoreRequest);
                ProjectsCreate = responseCreated.Data;

                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Projects created Successfully";
                ClearFields();

            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Projects Creation failed, Name already exists";
            }
        }

        private void ClearFields()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            chkStartEnddate.Checked = false;
            ddlManager.Text="Select...";
            ddlPriority.Text = "Select...";
        }

        protected void chkStartEnddate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartEnddate.Checked == true)
                pnlStartEndDate.Visible = true;
            else
                pnlStartEndDate.Visible = false;
        }
    }
}