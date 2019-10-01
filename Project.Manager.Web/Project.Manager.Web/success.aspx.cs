using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Manager.Web
{
    public partial class success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationManager.AppSettings["AppName"].ToString() + " : Success";
            if (Request.QueryString["success"] != null)
            {
                if (Request.QueryString["success"].ToString() == "reset-pwd")
                {
                    lblPasswordSuccessMsg.ForeColor = System.Drawing.Color.Green;
                    lblPasswordSuccessMsg.Text = "Your Password updated successfully, please login to your account.";
                }
            }
        }
    }
}