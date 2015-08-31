<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="userList.aspx.cs" Inherits="Donor.Web.admin.userList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             // Expand Selected Tab Section
             $(".main-menu a.expanded").removeClass("expanded");
             $("#aAdministration").addClass("expanded");
             $("#aAdministration").parent().children("ul").stop(true, true).slideDown("normal");

             var islast = '<%= IsLast %>';
            // alert(islast.toString());
            if (islast == 0) {
                $(".pagermenu > li > a").last().addClass("next animate");
            } else if (islast == 2) {
                $(".pagermenu > li > a").first().addClass("prev animate");
                $(".pagermenu > li > a").last().addClass("next animate");
            } else {
                $(".pagermenu > li > a").first().addClass("prev animate");
            }
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
        <li>View Users</li>
    </ul>
    <h1>View Users</h1>
    <hr />
    <a href="user.aspx" class="action-button flright animate">Add User</a>
    <br />
    <br />
    <div class="table">
        <table class="database-table">
            <thead>
                <tr><td width="5%">S.No.</td>
                    <td>Name</td>
                    <td>Email</td>
                    <td>Login Id</td>
                    
                    <td width="7%">Status</td>
                    <td width="17%" align="center">Action</td>
                </tr>
            </thead>
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_OnItemDataBound" OnItemCommand="rptList_OnItemCommand" >
                <ItemTemplate>
                    <tr><td><%# Container.ItemIndex + 1  %>
                            <asp:Label runat="server" ID="lblTypeId" Visible="False" Text='<%# Eval("TypeId")%>'></asp:Label>
                            <asp:Label runat="server" ID="lblUserId" Visible="False" Text='<%# Eval("UserId")%>'></asp:Label></td>
                        <td><%# Eval("UserName")%></td>
                        <td><%# Eval("EmailId")%></td>
                        <td><%# Eval("LoginId")%></td>
                        
                        <td><%# Eval("StatusTxt")%></td>
                        <td><a href="user.aspx?Id=<%# Eval("UserId")%>" class="table-edit-butn animate">
                            <i class="fa fa-edit"></i>Edit</a>
                            <asp:LinkButton ID="lkbDelete" runat="server" OnClientClick="return confirm('are you sure to delete the current record?');" 
                                CssClass="table-delete-butn animate"><i class="fa fa-trash-o"></i>Delete</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <div class="table-bottom grid">
            <div class="col-1-2">
                <asp:Literal runat="server" ID="litPageState"></asp:Literal>
            </div>
            <div class="col-1-2">
                <ul class="pagination flright">
                    <%--<li><a href="#" class="prev animate"><i class="fa fa-angle-left"></i></a></li>
                        <li><a href="#" class="animate current">1</a></li>
                        <li><a href="#" class="animate">2</a></li>
                        <li><a href="#" class="animate">3</a></li>
                        <li><a href="#" class="next animate"><i class="fa fa-angle-right"></i></a></li>--%>
                    <asp:Literal runat="server" ID="litPager"></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
