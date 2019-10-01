using Project.Manager.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Manager.Web
{
    public partial class passwordreset : System.Web.UI.Page
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEmailId.Value = Request.QueryString["emailid"].ToString();
            this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Password Reset";
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            
            var request = new RestRequest("user/byemail?emailid=" + hdnEmailId.Value, Method.GET);
            var response = client.Execute<User>(request);
            User _user = response.Data;

            
            _user.Password = txtPassword.Text;

            
            var postAdminRequest = new RestRequest("user/update?id=" + _user.UserId, Method.PUT);
            postAdminRequest.AddJsonBody(_user);
            var responseUpdated = client.Execute<User>(postAdminRequest);
            User _userUpdated = responseUpdated.Data;
            Response.Redirect("success.aspx?success=reset-pwd");
        }
    }
}