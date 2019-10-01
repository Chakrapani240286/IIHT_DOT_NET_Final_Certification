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
    public partial class userdetail : System.Web.UI.Page
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : User";
            if (Request.QueryString["Userid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnUserId.Value = Request.QueryString["Userid"].ToString();
                    int UserId = Convert.ToInt32(Request.QueryString["Userid"].ToString());

                    
                    var request = new RestRequest("user/byid?id=" + hdnUserId.Value, Method.GET);
                    var response = client.Execute<User>(request);
                    User _User = response.Data;

                    txtFirstName.Text = _User.FirstName;
                    txtLastName.Text = _User.LastName;
                    txtEmailId.Text = _User.EmailId;
                    chkIsDefault.Checked = (_User.Status.ToString().ToLower() == "active") ? true : false;
                    lblBcTitle.Text = _User.FirstName + "" + _User.LastName;
                    lblDateCreated.Text = _User.DateCreated.ToString("D");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(hdnUserId.Value);

            
            var request = new RestRequest("user/list", Method.GET);
            var response = client.Execute<List<User>>(request);
            List<User> _UserList = response.Data;

            User _otherStr = _UserList.Where(m => m.UserId != UserId && m.EmailId == txtEmailId.Text.Trim()).FirstOrDefault();
            if (_otherStr == null)
            {
                
                var request1 = new RestRequest("user/byid?id=" + hdnUserId.Value, Method.GET);
                var response1 = client.Execute<User>(request1);
                User User = response1.Data;

                User.FirstName = txtFirstName.Text;
                User.LastName = txtLastName.Text;
                User.EmailId = txtEmailId.Text;
                User.Status = (chkIsDefault.Checked) ? "Active" : "InActive";

                //Update the User detail to database
                var postUserRequest = new RestRequest("user/update?id=" + hdnUserId.Value, Method.PUT);
                postUserRequest.AddJsonBody(User);
                var responseUpdated = client.Execute<User>(postUserRequest);
                User _adminUpdated = responseUpdated.Data;

                Response.Redirect("/administration/Users.aspx?id=100&redirecturl=admin-User-rachna-teracotta");
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! User detail not updated successfully, because User Email should not be same as other";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            var request = new RestRequest("user/delete?id=" + hdnUserId.Value, Method.DELETE);
            var response = client.Execute<int>(request);
            int deleteId = response.Data;

            if (deleteId == 100)
            {
                Response.Redirect("/administration/Users.aspx?id=200&redirecturl=admin-User-rachna-teracotta");
            }
            else
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Failed! Unable to delete the selected User.";
            }
        }
    }
}