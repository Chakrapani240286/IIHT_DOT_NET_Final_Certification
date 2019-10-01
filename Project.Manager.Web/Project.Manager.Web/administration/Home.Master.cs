using Project.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Manager.Web.administration
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public User _User = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Check();
        }
        protected void Check()
        {
            if (Session[ConfigurationManager.AppSettings["AdminSession"]] == null)
            {
                string url = HttpContext.Current.Request.Url.PathAndQuery;
                Session["PreviousUrl"] = url;
                Response.Redirect("~/logout.aspx?logout=100&redUrl=HGHGH786876");
            }
            _User = (User)Session[ConfigurationManager.AppSettings["AdminSession"].ToString()];
        }
    }
}