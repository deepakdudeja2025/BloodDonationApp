using Donor.BAL;
using Donor.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Donor.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.ForeColor = Color.Red;
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var objUser = UserRepository.UserLoginValidate(Convert.ToString(txtLogin.Text.Trim()),
                    Convert.ToString(txtPwd.Text.Trim()));
                if (objUser != null && objUser.UserId >0)
                {
                    clsCookies.CookieCreateSession(objUser);
                    Response.Redirect("dashboard.aspx");
                }
                else
                {
                    lblMsg.Text = "Incorrect Login id or password. try again";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}