using Donor.BAL;
using Donor.Utility;
using PagerControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Donor.Web.admin
{
    public partial class userList : System.Web.UI.Page
    {
        public int IsLast { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMsg.Visible = false;
            lblMsg.Text = "";
            lblMsg.CssClass = "error";

            if (!IsPostBack)
            {
                PopulateUsers();
                if (Request.QueryString["msg"] != null)
                {
                    lblMsg.Text = Request.QueryString["msg"].ToString();
                    lblMsg.CssClass = "success";
                    pnlMsg.Visible = true;
                }
            }
        }
        protected void rptList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == WebConstant.CommandName.Delete)
            {
                
                if (UserRepository.UserDelete(TypeConversionUtility.ToInteger(e.CommandArgument)))
                {
                    PopulateUsers();
                    lblMsg.Text = "Record has been successfully deleted.";
                    pnlMsg.Visible = true;
                }
            }
        }
        protected void rptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = e.Item.DataItem;
                var lkbDelete = (LinkButton)e.Item.FindControl("lkbDelete");
                var lblTypeId = (Label)e.Item.FindControl("lblTypeId");
                var lblUserId = (Label)e.Item.FindControl("lblUserId");
                if (lblTypeId.Text != "1")
                {
                    if (lkbDelete != null)
                    {
                        lkbDelete.CommandName = WebConstant.CommandName.Delete;
                        lkbDelete.CommandArgument = lblUserId.Text.ToString();
                    }
                }
                else
                    lkbDelete.Visible = false;
            }
        }

        private void PopulateUsers()
        {
            try
            {
                int startPage = !String.IsNullOrEmpty(Request.QueryString[WebConstant.QueryString.PagerQueryString])
                    ? TypeConversionUtility.ToInteger(Request.QueryString[WebConstant.QueryString.PagerQueryString])
                    : 1;
                int pageLength =
                    !String.IsNullOrEmpty(Request.QueryString[WebConstant.QueryString.PageLengthQueryString])
                        ? TypeConversionUtility.ToInteger(
                            Request.QueryString[WebConstant.QueryString.PageLengthQueryString])
                        : WebConstant.PageLength;

                int noOfPages = 0;
                int totalRecords = 0;
                var users = UserRepository.UserListPaged(null, startPage, pageLength, out noOfPages, out totalRecords);
                rptList.DataSource = users;
                rptList.DataBind();

                #region "Paging"
                litPageState.Text = "Showing " + startPage + " of " + noOfPages + " (out of " + totalRecords + " items)";
                if (totalRecords > users.Count)
                {
                    ArgosPager argosPager = new ArgosPager();

                    argosPager.OutputFirstAndLastLinks = true;
                    argosPager.OutputPageStats = false;
                    argosPager.OutputPageJumper = false;
                    argosPager.EnableGoToPage = false;
                    argosPager.OutputNextPrevLinks = true;
                    argosPager.NavigateNextText = ">";
                    argosPager.NavigatePreviousText = "<";
                    PagerBuilder.BuildPager(startPage, pageLength, noOfPages, totalRecords, false, litPager,
                        WebConstant.PagerTextBoxId, WebConstant.QueryString.PagerQueryString, argosPager);

                    // Binding Paging Css on Pager Literal Control
                    string str = litPager.Text;
                    str = str.Replace("&nbsp;", "");
                    litPager.Text = str;
                    if (startPage != noOfPages)
                    {
                        int i = noOfPages / startPage;
                        if (i > 0 && startPage != 1)
                            IsLast = 2;
                        else
                            IsLast = 0;
                    }
                    else
                        IsLast = 1;
                }
                else
                    litPager.Text = "";
                #endregion
            }
            catch (Exception ex)
            {
                lblMsg.Text = string.Format("<p class=\"error\">{0}</p>", ex);
                pnlMsg.Visible = true;
            }
        }

    }
}