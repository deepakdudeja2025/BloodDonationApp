using Donor.BO;
using Donor.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Donor.Web.admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsCookies.CookieCheckSession();
            var user = new clsUser();
            clsCookies.CookieGetSession(user);
            lbAdminName.Text = user.UserName;
        }
    }
}