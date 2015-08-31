
using System.Web.UI.WebControls;

namespace Donor.Utility
{
    public class WebConstant
    {
        public const double feeDeductibleType = 10;
        public const double feeCoinsuranceType = 10;
        public const double feeDentalType = 5;
        public const string feeNameDeductibleType1 = "In network only.";
        public const string feeNameDeductibleType2 = "In and out of network.";
        public const string feeNameCoinsuranceType0 = "No";
        public const string feeNameCoinsuranceType1 = "Yes, in network deductible only.";
        public const string feeNameCoinsuranceType2 = "Yes, in and out of network deductible.";
        public const string feeNameDentalType0 = "No";
        public const string feeNameDentalType1 = "Yes, in network deductible only.";
        public const string feeNameDentalType2 = "Yes, in and out of network deductible.";

        public const string PagerTextBoxId = "PagerTextBoxID";
       
        public const string EntityId = "EntityId";
        public const string EntityType = "EntityType";
        public const string IsActive = "IsActive";
        public const string Status = "Status";
        public const string Id = "Id";
        public const string ProductId = "ProductId";
        public const string LocationId = "LocationId";
        public const string MBF = "MBF";
       
        public const string WebSiteUrl = "WebSiteUrl";
        public const string AttributesValue = "value";

        // Bind No iMages
        public const string NoImages = "no-img.jpg";
        public const string BackSlash = "/";      
        public const string D3 = "D3";
        public const string CssClass = "class";
        public const string CssClassAvailable = "available";
        public const string CssClassTaken = "taken";
        public const string SortOrderCommandName = "SortOrder";
      
        public const string FormatPlaceDecimalValue = "0.00";
        public const string DefaultDecimalValue = "0.00";
        public const string FormatCurrency = "{0:C}";
        public const string FormatDate = "MM/dd/yyyy";
        public const string FullDateFormat = "g";
        public const string DateFormat = "MM/dd/yyyy";
        public const string JoinSeprator = ":";
        public const string DefaultSelectedValue = "0";
        public const string DefaultSelectedText = "All ---";

        public const string AddUpdateErrorMessage = "There is some error occoured during save/update opertion. Please try again";

        public const string FontRedColorMessage = "<font color='red'>{0}</font>";
        public const string XSEGMENT = "X-SEGMENT";
        public const string XSEGMENTValue = "Sitco";
        public const string TextField = "Text";
        public const string ValueField = "Value";
        public const string KeyField = "Key";
        public const string PlusSymbol = " + ";

        public const int PageLength = 15;
        public const string ActiveText = "Active";
        public const string InActiveText = "Not Active";
        public const string YesText = "Yes";
        public const string NoText = "No";
        public const string DaysText = "Days";
        public const string DefaultSelectedCountry = "United States";

        public const string StyleDisplay = "display";
        public const string DisplayNone = "none";
        public const string DisplayBlock = "block";
        public const string Save = "Save";
        public const string Update = "Update";
        public const string DummyProductImage = "dummy.jpg";

        // Item Or Product Page Const
        public const string SearchStatusQueryString = "status";
        public const string SearchTypeQueryString = "type";
        public const string SearchTextQueryString = "s";
        public const string SearchFDateQueryString = "FDate";
        public const string SearchTDateQueryString = "TDate";
        public const string SortColumQueryString = "Sort";
        public const string SortOrderQueryString = "SO";

        public const string LocationIdQueryString = "LocationId";

        // Category 

        public const string CategoryId = "Id";
        public class EmailTemplate
        {
            public const string MailTemplate = "mailTemplate:";
            public const string TemplateReplaceFormat = "[[{0}]]";
            public const string ForgotPasswordTemplateName = "ForgotPasswordTemplateName";
            public const string ContactUsTemplateName = "ContactUs.htm";

            public class EmailKey
            {
                public const string PasswordKey = "Password";
                public const string FirstNameKey = "FirstName";
                public const string FirstName = "FirstName";
                public const string EmailIdKey = "Email";
                public const string CompanyName = "CompanyName";
                public const string LastNameKey = "LastName";
                public const string ContactPerson = "ContactPerson";
                public const string Phone = "Phone";
                public const string EmailSentOn = "EmailSentOn";
                public const string LogoImage = "LogoImage";
                public const string CommentText = "COMMENT";
            }
        }

        public class ViewStateKey
        {
            public const string ContextGuid = "ContextGuid";
            
        }

        public class ConfigKey
        {
            public const string CountryXMLPath = "CountryXMLPath";
            public const string StateXMLPath = "StateXMLPath";
            public const string PhysicalFilePath = "PhysicalFilePath";
            public const string SenderEmailAddress = "SenderEmailAddress";
            public const string EmailTemplatePath = "EmailTemplatePath";
            public const string WebSiteUrl = "WebSiteUrl";
            public const string IsEmailEnable = "IsEmailEnable";
            public const string AjaxUploaderGlobalMaxSizeKB = "AjaxUploaderGlobalMaxSizeKB";
            public const string AjaxUploaderTempDirectory = "AjaxUploaderTempDirectory";
            public const string FilePathVirtualUrl = "FilePathVirtualUrl";
            public const string ImageWidth = "ImageWidth";
            public const string ImageHeight = "ImageHeight";
            public const string BackOfficeEmail = "BackOfficeEmail";
        }
        public class QueryString
        {
            public const string LocationId = "lid";
            public const string PagerQueryString = "p";
            public const string PageLengthQueryString = "pageLength";
            public const string IsSearchQueryString = "s";
            public const string UserIdQueryString = "uId";
            public const string CategoryIdQueryString = "cId";
            public const string CmsPageIdQueryString = "cmsId";
            public const string LumberTypeIdQueryString = "ltId";
            public const string ProductIdQueryString = "pId";            
        }

        public class CommandName
        {
            public const string Delete = "Delete";
            public const string Approve = "Approve";
            public const string DisApprove = "DisApprove";
            public const string Edit = "Edit";
        }
        public class RoutingConstant
        {
            public const string RouteNameCmsPage = "CmsPageUrl";
            public const string PageUrlKey = "pageUrl";
            public const string RoutingKeyId = "id";
            public const string RoutingKeyProductName = "productname";
            public const string RoutingKeyPageNo = "pageno";
            public const string RouteNameProductDetail = "ProductDetail";
            public const string OnlyNumericRegx = @"^[0-9]*$";
            public const string ProductFolder = "product";
            public const int PageNoDefault = 1;
        }
    }//end class
}//end namespace