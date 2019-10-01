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
    public partial class forgotpassword : System.Web.UI.Page
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Forgot Password";
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            var request = new RestRequest("user/byemail?emailid=" + txtUserName.Text, Method.GET);
            var response = client.Execute<User>(request);
            User _user = response.Data;

            if (_user == null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblErrorMessage.Text = "Oops!!! Entered EmailId Does not exists in our database.";
            }
            else
            {
                Response.Redirect("passwordreset.aspx?emailid=" + txtUserName.Text);
            }
        }
    }
}