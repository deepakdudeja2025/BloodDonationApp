using Donor.BAL;
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
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.CssClass = "error";
            pnlMsg.Visible = false;

            if (!IsPostBack)
            {
                ClsCommon.FillStatus(ddlStatus);
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["Id"])))
                {
                    litbreadcrumbs.Text = litSubTitle.Text = "Edit User";
                    lkbSubmit.Text = "<i class='fa fa-refresh'></i>Update";
                    BindUserDetails();
                }
                else
                {
                    ClsCommon.FillLoginType(ddUserLevel);
                    ClsCommon.FillSelect(ddUserLevel);
                }
            }

        }
        protected void lkbSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
                var objUser = new clsUser();
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["Id"])))
                    objUser.UserId = TypeConversionUtility.ToInteger(Request.QueryString["Id"]);
                else
                    objUser.UserId = 0;
                objUser.UserName = TypeConversionUtility.ToStringWithNull(txtName.Text.Trim());
                objUser.EmailId = TypeConversionUtility.ToStringWithNull(txtEmailId.Text.Trim());
                objUser.LoginId = TypeConversionUtility.ToStringWithNull(txtLoginId.Text.Trim());
                objUser.LoginPwd = TypeConversionUtility.ToStringWithNull(txtPwd.Text.Trim());
                objUser.Status = TypeConversionUtility.ToInteger(ddlStatus.SelectedValue);
                objUser.TypeId = Convert.ToInt32(ddUserLevel.SelectedValue);

                if (UserRepository.CheckUserExits(objUser.UserId, objUser.LoginId))
                {
                    lblMsg.Text = "Login Id already exist. Try using different login id.";
                    pnlMsg.Visible = true;
                }
                else if (UserRepository.UserAddUpdate(objUser)) // Add/Update Login Details
                {
                    if (objUser.UserId == 0)
                    {
                        pnlMsg.Visible = true;
                        lblMsg.Text = "Record has been successfully inserted.";
                        lblMsg.CssClass = "success";
                        txtName.Text = "";
                        txtEmailId.Text = "";
                        txtPwd.Text = "";
                        txtLoginId.Text = "";
                        ddlStatus.SelectedValue = "0";
                    }
                    else
                        Response.Redirect("userList.aspx?msg=Record has been successfully updated.");
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = string.Format("<p class=\"error\">{0}</p>", ex);
                pnlMsg.Visible = true;
            }

        }
        private void BindUserDetails()
        {
            var objUser = UserRepository.UserDetails(Convert.ToInt32(Request.QueryString["Id"]));
            if (objUser!=null)
            {
                txtName.Text = objUser.UserName;
                txtEmailId.Text = objUser.EmailId;
                txtLoginId.Text = Convert.ToString(objUser.LoginId);
                txtPwd.Attributes.Add("value", objUser.LoginPwd);
                ddlStatus.SelectedValue = objUser.Status.ToString();
                if (objUser.TypeId == 1)
                {
                    ClsCommon.FillLoginTypeAdmin(ddUserLevel);
                    ddUserLevel.Enabled = false;
                    ddlStatus.Enabled = false;
                }
                else
                    ClsCommon.FillLoginType(ddUserLevel);
                ClsCommon.FillSelect(ddUserLevel);
                ddUserLevel.SelectedValue = objUser.TypeId.ToString();
            }
        }
    }
}