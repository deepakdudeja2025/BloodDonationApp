<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Donor.Web.admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>GEM :: Authenticaion</title>
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/screen.css" media="screen, projection" rel="stylesheet" type="text/css" />
	<!--[if IE]>
		<link href="css/ie.css" media="screen, projection" rel="stylesheet" type="text/css" />
	<![endif]-->

    <script language="javascript" type="text/javascript">
        function closeMsg(val) {
            document.getElementById(val).style.display = "none";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">    
     <header>
            <div class="header-left"><%--<img src="images/client-logo.png" alt="" />--%></div>
            <div class="header-right">&nbsp;</div>
        </header>
        <div class="page-container">
            <div class="page-content" style="width:70%">
                <h1>User Authentication</h1>
                <hr />
                <br />
                <br />

                <div class="table">
                    <ul class="form-items">
                        <li><label>&nbsp;</label><asp:Label ID="lblMsg" runat="server" CssClass="starbig"></asp:Label></li>
                        <li>
					        <label>Login Id:</label>
                            <asp:TextBox ID="txtLogin" runat="server" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin" CssClass="star" 
                                Display="Dynamic" ErrorMessage="required" SetFocusOnError="True"></asp:RequiredFieldValidator></li>
                        <li><label>Password:</label>
                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd" CssClass="star" 
                                Display="Dynamic" ErrorMessage="required" SetFocusOnError="True"></asp:RequiredFieldValidator></li>				
                        <li>&nbsp;</li>
                        <li>&nbsp;</li>
					</ul>

                    <div class="form-bottom">
                        <asp:Button runat="server" ID="lbLogin" Text="Log In" style="border: 0px solid #ccc;"
                            CssClass="form-action-button animate" onclick="lbLogin_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
