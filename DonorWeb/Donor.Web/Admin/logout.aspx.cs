using Donor.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Donor.Web.admin
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsCookies.CookieDelete();
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}