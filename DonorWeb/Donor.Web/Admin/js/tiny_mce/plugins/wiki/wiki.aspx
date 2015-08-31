<%@ Page Language="C#" Inherits="Communifire.Web.Components.BasePage" %>
<%@ Import Namespace="System.Linq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">


</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>{#wiki_dlg.title}</title>
    
    <CFControl:Link Href="assets/css/dyve-styles.css" runat="server"></CFControl:Link>
    <CFControl:Link Href="assets/scripts/jquery/autocomplete/jquery.autocomplete.css" runat="server"/>
    <CFControl:Script ScriptSrc="assets/scripts/jquery/jquery-1.4.2.min.js" runat="server"/>
    <CFControl:Script ScriptSrc="assets/scripts/jquery/autocomplete/jquery.autocomplete.js" runat="server"/>
    
    <script type="text/javascript" src="../../tiny_mce_popup.js"></script>
   
    <script type="text/javascript" src="js/wiki.js"></script>
    <style type="text/css">
        h4{color:#333;}
    </style>
</head>
<body >
<form id="HtmlForm" runat="server" onsubmit="WikiDialog.insert();return false;" action="#">
<table class="formtable" cellpadding="0" cellspacing="0">
<tbody>
    <tr>
        <th colspan="2"><h4>{#wiki_dlg.linkAPage}</h4></th>
    </tr>
    <tr>
        <td colspan="2">
            <div style="padding:10px; overflow:hidden;width:auto;">
                Use the form below to add a hyperlink into your current wiki 
                page that leads to another wiki page.  When entering a page 
                name an autosuggest box will appear, giving you a list of existing 
                wiki pages to choose from. Then, add the link text below and click 
                the insert button.
            </div>
        </td>
    </tr>
    <tr>
        <td class="axero-table-cell-label">{#wiki_dlg.selectSpace}:</td>
        <td><CFControl:WikiLinkWikiPageSpacesDropDownList runat="server" ID="ddlSpace" ShowLoggedInUserSpaces="true" AutoPopulate="true" Width="310px"/></td>            
  
    </tr>
    <tr>
        <td class="axero-table-cell-label">{#wiki_dlg.enterPageName}:</td>
        <td>
            <div class="autocomplete-search-result-textbox-container">
                <asp:TextBox ID="AutoCompleteSearchTextbox" runat="server" CssClass="autocomplete-search-textbox textBox" ></asp:TextBox>
            </div>

            <div runat="server" id="AutocompleteSearchResultDiv" class="autocomplete-search-result">

                <div id="AutocompleteSearchResultHeaderDiv" class="autocomplete-search-result-header-div">
                    <ul>
                        <li runat="server" id="AutocompleteSearchResultHeader" class="autocomplete-search-result-header"></li>
                    </ul>
                </div>
                
                <div runat ="server" id="AutocompleteSearchResultContent" class="autocomplete-search-result-content"></div>
                
            </div>
        </td>
    </tr>
    <tr>
        <td class="axero-table-cell-label">{#wiki_dlg.enterPageLinkText}:</td>
        <td><input id="pageLinkText" name="pageLinkText" type="text" class="autocomplete-search-textbox textBox" /></td>
    </tr>
    <tr>
        <td class="axero-table-cell-label"></td>
        <td class="axero-table-cell-submit">
            <hr />
            <input type="button" id="Ainsert" name="insert" class="" value="{#insert}" onclick="WikiDialog.insert();" />
            <input type="button" id="Acancel" name="cancel" class="" value="{#cancel}" onclick="tinyMCEPopup.close();" />
        </td>
    </tr>
</tbody>
</table>
</form>

</html>
