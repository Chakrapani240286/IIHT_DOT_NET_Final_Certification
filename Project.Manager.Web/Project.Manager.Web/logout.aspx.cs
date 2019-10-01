using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Manager.Web
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sessionObjects = new List<string>();
            foreach (var item in HttpContext.Current.Session)
            {
                if (item.ToString() != "PreviousUrl")
                {
                    sessionObjects.Add(item.ToString());
                }
            }
            foreach (var item in sessionObjects)
            {
                Session[item] = null;
            }
            if (Request.QueryString["logout"] == "100")
            {
                lblLogoutMessage.Text = "Ohoo!!! You Have successfully logged out successfully.";
            }
            else if (Request.QueryString["logout"] == "1000")
            {
                lblLogoutMessage.Text = "Ohoo!!! Password Changed Successfully, So you have successfully logged out from the application.";
            }
            else
            {
                lblLogoutMessage.Text = "Oops!!! We are sorry!! your account logged out due to inactivity.";
            }

            this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Logged Out";
        }
    }
}