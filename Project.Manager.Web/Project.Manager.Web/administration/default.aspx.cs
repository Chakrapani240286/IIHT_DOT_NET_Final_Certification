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
    public partial class _default : System.Web.UI.Page
    {
        public User _User;
        protected void Page_Load(object sender, EventArgs e)
        {
            _User = (User)Session[ConfigurationManager.AppSettings["AdminSession"].ToString()];
        }
    }
}