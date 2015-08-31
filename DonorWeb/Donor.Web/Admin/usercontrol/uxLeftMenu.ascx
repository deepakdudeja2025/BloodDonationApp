<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uxLeftMenu.ascx.cs" Inherits="Donor.Web.admin.usercontrol.uxLeftMenu" %>
<ul class="main-menu">
    
    <li class="has-sub">
	    <a href="javascript:void(0);" id="aSettings"><i class="fa fa-gear" ></i><span>Site Settings</span></a>
		<ul class="sub-items">
		    <li><a href="#">Home Page </a></li>
        </ul>
	</li>
    <li class="has-sub">
        <a href="javascript:void(0);" id="aAdministration"><i class="fa fa-user"></i><span>Administration</span></a>
		<ul class="sub-items">
            <li><a href="userList.aspx">View Users</a></li>
            
        </ul>
	</li>
</ul>
