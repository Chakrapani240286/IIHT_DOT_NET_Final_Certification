using Project.Manager.Entities;
using Project.Manager.Web.Helper;
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
    public partial class _default : System.Web.UI.Page
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["loginrredirectUrl"] != null)
            {
                this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Login";
            }
            else
            {
                Response.Redirect("/default.aspx?loginrredirectUrl=login-administrator-home&pageId=admin-login.html");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var request = new RestRequest("user/byemail?emailid=" + txtUserName.Text, Method.GET);
            var response = client.Execute<User>(request);
            User _user = response.Data;

            if (_user == null)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblErrorMessage.Text = "Oops!!! No entered email id exists in our database.";
            }
            else if (_user.Status.ToLower() == "inactive")
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblErrorMessage.Text = "Oops!!! Cannot login to your account, becaues your account is inactive. Please raise request to activate your account.";
            }
            else if (PasswordProtect.Decrypt(_user.Password) != txtPassword.Text)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblErrorMessage.Text = "Oops!!! Entered password is invalid for entered emailid.";
            }
            else
            {
                pnlErrorMessage.Visible = false;
                lblErrorMessage.Text = "";

                Session[ConfigurationManager.AppSettings["AdminSession"].ToString()] = _user;

                if (Session["PreviousUrl"] != null)
                {
                    Response.Redirect(Session["PreviousUrl"].ToString(), false);
                }
                else
                {
                    Response.Redirect("/administration/default.aspx?redirecturl=rachna-teracotta-home");
                }
            }
        }
    }
}