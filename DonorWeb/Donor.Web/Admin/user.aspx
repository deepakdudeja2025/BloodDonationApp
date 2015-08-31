<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="Donor.Web.admin.user" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            // Expand Selected Tab Section
            $(".main-menu a.expanded").removeClass("expanded");
            $("#aAdministration").addClass("expanded");
            $("#aAdministration").parent().children("ul").stop(true, true).slideDown("normal");
        });
    </script>
    <asp:UpdatePanel ID="uxUpdatePanel" runat="server">
    <ContentTemplate>
        <div>
            <asp:Panel ID="pnlMsg" runat="server" Width="100%" BorderWidth="0" BorderStyle="None" style="z-index: 999;" 
                BackImageUrl="images/black.png">
                <div style="width: 99%; height: auto; vertical-align: middle; text-align: center; padding:7px;">
                    <a href="#" onclick="javascript:closeMsg('<%=pnlMsg.ClientID %>'); return false;">
                        <img src="images/close.png" alt="close" border="0" align="right" /></a>
                    <asp:Label ID="lblMsg" runat="server" CssClass="starbig"></asp:Label></div></asp:Panel>
            <asp:AlwaysVisibleControlExtender ID="avce" runat="server" TargetControlID="pnlMsg" VerticalSide="Top"
                VerticalOffset="0" HorizontalSide="Center" HorizontalOffset="0" ScrollEffectDuration="10" /></div>
    </ContentTemplate>
    </asp:UpdatePanel>

    <ul class="breadcrumbs">
        <li><a href="dashboard.aspx"><i class="fa fa-home"></i>Home</a></li>
        <li><a href="#">Administration</a></li>
        <li><a href="#">View Users</a></li>
        <li><asp:Literal ID="litbreadcrumbs" runat="server" Text="Add User"></asp:Literal></li>
    </ul>
    <div class="table">
        <div class="form-top">
            <h2><asp:Literal ID="litSubTitle" runat="server" Text="Add User"></asp:Literal></h2>
        </div>
		<ul class="form-items">
		    <li>
		        <label>Name:</label>
                <asp:TextBox ID="txtName" runat="server" MaxLength="100"/>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" CssClass="star" 
                    ControlToValidate="txtName" ErrorMessage="required" SetFocusOnError="True" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
		    </li>
            <li>
		        <label>Email Id:</label>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100"/>
                <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" 
                    ControlToValidate="txtEmailId" CssClass="star" ErrorMessage="required" 
                    SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailId" runat="server" 
                    ControlToValidate="txtEmailId" ErrorMessage="required valid email address" 
                    SetFocusOnError="True" Display="Dynamic" CssClass="star"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </li>
            <li>
                <label>Login Id:</label>
                <asp:TextBox ID="txtLoginId" runat="server" MaxLength="50"/>
                <asp:RequiredFieldValidator ID="rfvLoginid" runat="server" CssClass="star" 
                    ControlToValidate="txtLoginId" ErrorMessage="required" SetFocusOnError="True" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>Password:</label>
                <asp:TextBox ID="txtPwd" runat="server" MaxLength="30" TextMode="Password"/>
                <asp:RequiredFieldValidator ID="rfvPwd" runat="server" CssClass="star" 
                    ControlToValidate="txtPwd" ErrorMessage="required" SetFocusOnError="True" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </li>
            <li>
                <label>User Level:</label>
                <label class="dropdown"><asp:DropDownList ID="ddUserLevel" runat="server" CssClass="select-dropdown form-items"/></label>
                <asp:RequiredFieldValidator ID="rfUserLevel" runat="server" CssClass="star" 
                    ControlToValidate="ddUserLevel" ErrorMessage="required" SetFocusOnError="True" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </li>
		    <li>
                <label>Status:</label>
                <label class="dropdown"><asp:DropDownList ID="ddlStatus" runat="server" CssClass="select-dropdown form-items"/></label>
                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" 
                    ControlToValidate="ddlStatus" CssClass="star" ErrorMessage="required" 
                    SetFocusOnError="True" Display="Dynamic" 
                    InitialValue="-1"></asp:RequiredFieldValidator>
		    </li>
        </ul>
		<div class="form-bottom">
		    <asp:LinkButton ID="lkbSubmit" runat="server" OnClick="lkbSubmit_OnClick" CssClass="form-action-button animate" Text="<i class='fa fa-refresh'></i>Submit"></asp:LinkButton>
            <a href="#" class="action-button animate" onclick="window.location='userList.aspx'">Cancel</a>
        </div>
    </div>
</asp:Content>
