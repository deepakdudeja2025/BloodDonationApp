using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using System.Linq;
using System.ComponentModel;

/// <summary>
/// Summary description for ClsCommon
/// </summary>
namespace Donor.Utility
{
    public static class ClsCommon
    {
        #region Prefilled data on Page
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            List<IDataRecord> list = data.Cast<IDataRecord>().ToList();

            PropertyDescriptorCollection props = null;
            DataTable table = new DataTable();
            if (list != null && list.Count > 0)
            {
                props = TypeDescriptor.GetProperties(list[0]);
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }
            if (props != null)
            {
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(values);
                }
            }
            return table;
        }
        public static void FillDeductibleType(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("In network only", "1"));
            ddlList.Items.Add(new ListItem("In and out of network", "2"));
            ddlList.Items.Insert(0, new ListItem(" select ", ""));
        }
        public static void FillCoInsuranceType(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("Yes, in network deductible only", "1"));
            ddlList.Items.Add(new ListItem("Yes, in and out of network deductible only", "2"));
            ddlList.Items.Add(new ListItem("No", "0"));
            ddlList.Items.Insert(0, new ListItem(" select ", "-1"));
        }
        public static void FillDentalType(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("Yes, in network deductible only", "1"));
            ddlList.Items.Add(new ListItem("Yes, in and out of network deductible only", "2"));
            ddlList.Items.Add(new ListItem("No", "0"));
            ddlList.Items.Insert(0, new ListItem(" select ", "-1"));
        }
        /*********************** Filling DropDowns With Static Values ***************************************/
       
        public static void FillSelect(DropDownList ddlList)
        {
            ddlList.Items.Insert(0, new ListItem("Select", ""));
        }
        public static void FillSelectSmall(DropDownList ddlList)
        {
            ddlList.Items.Insert(0, new ListItem("select", ""));
        }
        public static void FillSelect0(DropDownList ddlList)
        {
            ddlList.Items.Insert(0, new ListItem("Select------->", "0"));
        }
        public static void FillSelect0WithName(DropDownList ddlList, string sName)
        {
            ddlList.Items.Insert(0, new ListItem(sName, "0"));
        }
        public static void FillSelectWithName(DropDownList ddlList, string sName)
        {
            ddlList.Items.Insert(0, new ListItem(sName, ""));
        }
        public static void FillSelectAll(DropDownList ddlList)
        {
            ddlList.Items.Insert(0, new ListItem("--------- All ---------", "0"));
        }

       
        public static void FillStatus(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("Active", "1"));
            ddlList.Items.Add(new ListItem("In Active", "0"));
        }
        public static void FillLoginType(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("Admin", "0"));            
            ddlList.Items.Add(new ListItem("SEO User", "2"));
        }
        public static void FillLoginTypeAdmin(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("Admin", "1"));
            ddlList.Items.Add(new ListItem("SEO User", "2"));
        }
        public static void FillYesNo(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("No", "0"));
            ddlList.Items.Add(new ListItem("Yes", "1"));
        }
        public static void FillYesNo(RadioButtonList ddlList)
        {
            ddlList.Items.Add(new ListItem("Yes", "1"));
            ddlList.Items.Add(new ListItem("No", "0"));
        }
        public static void FillGender(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("Male", "M"));
            ddlList.Items.Add(new ListItem("Female", "F"));
            ddlList.Items.Insert(0, new ListItem(" Select ", "0"));
        }
       public static void FillMonth(DropDownList ddlList)
        {
            ddlList.Items.Add((new ListItem("January", "1")));
            ddlList.Items.Add((new ListItem("February", "2")));
            ddlList.Items.Add((new ListItem("March", "3")));
            ddlList.Items.Add((new ListItem("April", "4")));
            ddlList.Items.Add((new ListItem("May", "5")));
            ddlList.Items.Add((new ListItem("June", "6")));
            ddlList.Items.Add((new ListItem("July", "7")));
            ddlList.Items.Add((new ListItem("August", "8")));
            ddlList.Items.Add((new ListItem("September", "9")));
            ddlList.Items.Add((new ListItem("October", "10")));
            ddlList.Items.Add((new ListItem("November", "11")));
            ddlList.Items.Add((new ListItem("December", "12")));
            ddlList.Items.Insert(0, new ListItem(" Month ", "0"));
        }
        public static void FillCountry(DropDownList ddlList)
        {
            ddlList.Items.Add(new ListItem("Afghanistan", "Afghanistan"));
            ddlList.Items.Add(new ListItem("Albania", "Albania"));
            ddlList.Items.Add(new ListItem("Algeria", "Algeria"));
            ddlList.Items.Add(new ListItem("American Samoa", "American Samoa"));
            ddlList.Items.Add(new ListItem("Andorra", "Andorra"));
            ddlList.Items.Add(new ListItem("Angola", "Angola"));
            ddlList.Items.Add(new ListItem("Anguilla", "Anguilla"));
            ddlList.Items.Add(new ListItem("Antarctica", "Antarctica"));
            ddlList.Items.Add(new ListItem("Argentina", "Argentina"));
            ddlList.Items.Add(new ListItem("Armenia", "Armenia"));
            ddlList.Items.Add(new ListItem("Aruba", "Aruba"));
            ddlList.Items.Add(new ListItem("Australia", "Australia"));
            ddlList.Items.Add(new ListItem("Austria", "Austria"));
            ddlList.Items.Add(new ListItem("Azerbaijan", "Azerbaijan"));
            ddlList.Items.Add(new ListItem("Bahamas", "Bahamas"));
            ddlList.Items.Add(new ListItem("Bahrain", "Bahrain"));
            ddlList.Items.Add(new ListItem("Bangladesh", "Bangladesh"));
            ddlList.Items.Add(new ListItem("Barbados", "Barbados"));
            ddlList.Items.Add(new ListItem("Belarus", "Belarus"));
            ddlList.Items.Add(new ListItem("Belgium", "Belgium"));
            ddlList.Items.Add(new ListItem("Belize", "Belize"));
            ddlList.Items.Add(new ListItem("Benin", "Benin"));
            ddlList.Items.Add(new ListItem("Bermuda", "Bermuda"));
            ddlList.Items.Add(new ListItem("Bhutan", "Bhutan"));
            ddlList.Items.Add(new ListItem("Plurinational State of Bolivia", "Plurinational State of Bolivia"));
            ddlList.Items.Add(new ListItem("Botswana", "Botswana"));
            ddlList.Items.Add(new ListItem("Bouvet Island", "Bouvet Island"));
            ddlList.Items.Add(new ListItem("Brazil", "Brazil"));
            ddlList.Items.Add(new ListItem("Bulgaria", "Bulgaria"));
            ddlList.Items.Add(new ListItem("Burkina Faso", "Burkina Faso"));
            ddlList.Items.Add(new ListItem("Burundi", "Burundi"));
            ddlList.Items.Add(new ListItem("Cambodia", "Cambodia"));
            ddlList.Items.Add(new ListItem("Cameroon", "Cameroon"));
            ddlList.Items.Add(new ListItem("Canada", "Canada"));
            ddlList.Items.Add(new ListItem("Cape Verde", "Cape Verde"));
            ddlList.Items.Add(new ListItem("Cayman Islands", "Cayman Islands"));
            ddlList.Items.Add(new ListItem("Chad", "Chad"));
            ddlList.Items.Add(new ListItem("Chile", "Chile"));
            ddlList.Items.Add(new ListItem("China", "China"));
            ddlList.Items.Add(new ListItem("Comoros", "Comoros"));
            ddlList.Items.Add(new ListItem("Congo", "Congo"));
            ddlList.Items.Add(new ListItem("Cook Islands", "Cook Islands"));
            ddlList.Items.Add(new ListItem("Costa Rica", "Costa Rica"));
            ddlList.Items.Add(new ListItem("Cote d'Ivoire", "Cote d'Ivoire"));
            ddlList.Items.Add(new ListItem("Croatia", "Croatia"));
            ddlList.Items.Add(new ListItem("Cuba", "Cuba"));
            ddlList.Items.Add(new ListItem("Cyprus", "Cyprus"));
            ddlList.Items.Add(new ListItem("Czech Republic", "Czech Republic"));
            ddlList.Items.Add(new ListItem("Denmark", "Denmark"));
            ddlList.Items.Add(new ListItem("Djibouti", "Djibouti"));
            ddlList.Items.Add(new ListItem("Dominica", "Dominica"));
            ddlList.Items.Add(new ListItem("Ecuador", "Ecuador"));
            ddlList.Items.Add(new ListItem("Egypt", "Egypt"));
            ddlList.Items.Add(new ListItem("El Salvador", "El Salvador"));
            ddlList.Items.Add(new ListItem("Equatorial Guinea", "Equatorial Guinea"));
            ddlList.Items.Add(new ListItem("Eritrea", "Eritrea"));
            ddlList.Items.Add(new ListItem("Estonia", "Estonia"));
            ddlList.Items.Add(new ListItem("Ethiopia", "Ethiopia"));
            ddlList.Items.Add(new ListItem("Falkland Islands (Malvinas)", "Falkland Islands (Malvinas)"));
            ddlList.Items.Add(new ListItem("Faroe Islands", "Faroe Islands"));
            ddlList.Items.Add(new ListItem("Fiji", "Fiji"));
            ddlList.Items.Add(new ListItem("Finland", "Finland"));
            ddlList.Items.Add(new ListItem("France", "France"));
            ddlList.Items.Add(new ListItem("French Guiana", "French Guiana"));
            ddlList.Items.Add(new ListItem("French Polynesia", "French Polynesia"));
            ddlList.Items.Add(new ListItem("Gabon", "Gabon"));
            ddlList.Items.Add(new ListItem("Gambia", "Gambia"));
            ddlList.Items.Add(new ListItem("Georgia", "Georgia"));
            ddlList.Items.Add(new ListItem("Germany", "Germany"));
            ddlList.Items.Add(new ListItem("Ghana", "Ghana"));
            ddlList.Items.Add(new ListItem("Gibraltar", "Gibraltar"));
            ddlList.Items.Add(new ListItem("Greece", "Greece"));
            ddlList.Items.Add(new ListItem("Greenland", "Greenland"));
            ddlList.Items.Add(new ListItem("Grenada", "Grenada"));
            ddlList.Items.Add(new ListItem("Guadeloupe", "Guadeloupe"));
            ddlList.Items.Add(new ListItem("Guam", "Guam"));
            ddlList.Items.Add(new ListItem("Guatemala", "Guatemala"));
            ddlList.Items.Add(new ListItem("Guinea", "Guinea"));
            ddlList.Items.Add(new ListItem("Guinea-Bissau", "Guinea-Bissau"));
            ddlList.Items.Add(new ListItem("Guyana", "Guyana"));
            ddlList.Items.Add(new ListItem("Haiti", "Haiti"));
            ddlList.Items.Add(new ListItem("Holy See (Vatican City State)", "Holy See (Vatican City State)"));
            ddlList.Items.Add(new ListItem("Honduras", "Honduras"));
            ddlList.Items.Add(new ListItem("Hong Kong", "Hong Kong"));
            ddlList.Items.Add(new ListItem("Hungary", "Hungary"));
            ddlList.Items.Add(new ListItem("Iceland", "Iceland"));
            ddlList.Items.Add(new ListItem("India", "India"));
            ddlList.Items.Add(new ListItem("Indonesia", "Indonesia"));
            ddlList.Items.Add(new ListItem("Iraq", "Iraq"));
            ddlList.Items.Add(new ListItem("Ireland", "Ireland"));
            ddlList.Items.Add(new ListItem("Israel", "Israel"));
            ddlList.Items.Add(new ListItem("Italy", "Italy"));
            ddlList.Items.Add(new ListItem("Jamaica", "Jamaica"));
            ddlList.Items.Add(new ListItem("Japan", "Japan"));
            ddlList.Items.Add(new ListItem("Jordan", "Jordan"));
            ddlList.Items.Add(new ListItem("Kazakhstan", "Kazakhstan"));
            ddlList.Items.Add(new ListItem("Kenya", "Kenya"));
            ddlList.Items.Add(new ListItem("Kiribati", "Kiribati"));
            ddlList.Items.Add(new ListItem("Kuwait", "Kuwait"));
            ddlList.Items.Add(new ListItem("Kyrgyzstan", "Kyrgyzstan"));
            ddlList.Items.Add(new ListItem("Latvia", "Latvia"));
            ddlList.Items.Add(new ListItem("Lebanon", "Lebanon"));
            ddlList.Items.Add(new ListItem("Lesotho", "Lesotho"));
            ddlList.Items.Add(new ListItem("Liberia", "Liberia"));
            ddlList.Items.Add(new ListItem("Liechtenstein", "Liechtenstein"));
            ddlList.Items.Add(new ListItem("Lithuania", "Lithuania"));
            ddlList.Items.Add(new ListItem("Luxembourg", "Luxembourg"));
            ddlList.Items.Add(new ListItem("Macao", "Macao"));
            ddlList.Items.Add(new ListItem("Madagascar", "Madagascar"));
            ddlList.Items.Add(new ListItem("Malawi", "Malawi"));
            ddlList.Items.Add(new ListItem("Malaysia", "Malaysia"));
            ddlList.Items.Add(new ListItem("Maldives", "Maldives"));
            ddlList.Items.Add(new ListItem("Mali", "Mali"));
            ddlList.Items.Add(new ListItem("Malta", "Malta"));
            ddlList.Items.Add(new ListItem("Marshall Islands", "Marshall Islands"));
            ddlList.Items.Add(new ListItem("Martinique", "Martinique"));
            ddlList.Items.Add(new ListItem("Mauritania", "Mauritania"));
            ddlList.Items.Add(new ListItem("Mauritius", "Mauritius"));
            ddlList.Items.Add(new ListItem("Mayotte", "Mayotte"));
            ddlList.Items.Add(new ListItem("Mexico", "Mexico"));
            ddlList.Items.Add(new ListItem("Monaco", "Monaco"));
            ddlList.Items.Add(new ListItem("Mongolia", "Mongolia"));
            ddlList.Items.Add(new ListItem("Montserrat", "Montserrat"));
            ddlList.Items.Add(new ListItem("Morocco", "Morocco"));
            ddlList.Items.Add(new ListItem("Mozambique", "Mozambique"));
            ddlList.Items.Add(new ListItem("Myanmar", "Myanmar"));
            ddlList.Items.Add(new ListItem("Namibia", "Namibia"));
            ddlList.Items.Add(new ListItem("Nauru", "Nauru"));
            ddlList.Items.Add(new ListItem("Nepal", "Nepal"));
            ddlList.Items.Add(new ListItem("Netherlands", "Netherlands"));
            ddlList.Items.Add(new ListItem("New Caledonia", "New Caledonia"));
            ddlList.Items.Add(new ListItem("New Zealand", "New Zealand"));
            ddlList.Items.Add(new ListItem("Nicaragua", "Nicaragua"));
            ddlList.Items.Add(new ListItem("Niger", "Niger"));
            ddlList.Items.Add(new ListItem("Nigeria", "Nigeria"));
            ddlList.Items.Add(new ListItem("Niue", "Niue"));
            ddlList.Items.Add(new ListItem("Norway", "Norway"));
            ddlList.Items.Add(new ListItem("Oman", "Oman"));
            ddlList.Items.Add(new ListItem("Pakistan", "Pakistan"));
            ddlList.Items.Add(new ListItem("Palau", "Palau"));
            ddlList.Items.Add(new ListItem("Panama", "Panama"));
            ddlList.Items.Add(new ListItem("Paraguay", "Paraguay"));
            ddlList.Items.Add(new ListItem("Peru", "Peru"));
            ddlList.Items.Add(new ListItem("Philippines", "Philippines"));
            ddlList.Items.Add(new ListItem("Pitcairn", "Pitcairn"));
            ddlList.Items.Add(new ListItem("Poland", "Poland"));
            ddlList.Items.Add(new ListItem("Portugal", "Portugal"));
            ddlList.Items.Add(new ListItem("Puerto Rico", "Puerto Rico"));
            ddlList.Items.Add(new ListItem("Qatar", "Qatar"));
            ddlList.Items.Add(new ListItem("Reunion", "Reunion"));
            ddlList.Items.Add(new ListItem("Romania", "Romania"));
            ddlList.Items.Add(new ListItem("Rwanda", "Rwanda"));
            ddlList.Items.Add(new ListItem("Saint Helena", "Saint Helena"));
            ddlList.Items.Add(new ListItem("Saint Lucia", "Saint Lucia"));
            ddlList.Items.Add(new ListItem("Samoa", "Samoa"));
            ddlList.Items.Add(new ListItem("San Marino", "San Marino"));
            ddlList.Items.Add(new ListItem("Saudi Arabia", "Saudi Arabia"));
            ddlList.Items.Add(new ListItem("Senegal", "Senegal"));
            ddlList.Items.Add(new ListItem("Seychelles", "Seychelles"));
            ddlList.Items.Add(new ListItem("Sierra Leone", "Sierra Leone"));
            ddlList.Items.Add(new ListItem("Singapore", "Singapore"));
            ddlList.Items.Add(new ListItem("Slovakia", "Slovakia"));
            ddlList.Items.Add(new ListItem("Slovenia", "Slovenia"));
            ddlList.Items.Add(new ListItem("Solomon Islands", "Solomon Islands"));
            ddlList.Items.Add(new ListItem("Somalia", "Somalia"));
            ddlList.Items.Add(new ListItem("South Africa", "South Africa"));
            ddlList.Items.Add(new ListItem("Spain", "Spain"));
            ddlList.Items.Add(new ListItem("Sri Lanka", "Sri Lanka"));
            ddlList.Items.Add(new ListItem("Sudan", "Sudan"));
            ddlList.Items.Add(new ListItem("Suriname", "Suriname"));
            ddlList.Items.Add(new ListItem("Swaziland", "Swaziland"));
            ddlList.Items.Add(new ListItem("Sweden", "Sweden"));
            ddlList.Items.Add(new ListItem("Switzerland", "Switzerland"));
            ddlList.Items.Add(new ListItem("Tajikistan", "Tajikistan"));
            ddlList.Items.Add(new ListItem("Thailand", "Thailand"));
            ddlList.Items.Add(new ListItem("Timor-Leste", "Timor-Leste"));
            ddlList.Items.Add(new ListItem("Togo", "Togo"));
            ddlList.Items.Add(new ListItem("Tokelau", "Tokelau"));
            ddlList.Items.Add(new ListItem("Tonga", "Tonga"));
            ddlList.Items.Add(new ListItem("Tunisia", "Tunisia"));
            ddlList.Items.Add(new ListItem("Turkey", "Turkey"));
            ddlList.Items.Add(new ListItem("Turkmenistan", "Turkmenistan"));
            ddlList.Items.Add(new ListItem("Tuvalu", "Tuvalu"));
            ddlList.Items.Add(new ListItem("Uganda", "Uganda"));
            ddlList.Items.Add(new ListItem("Ukraine", "Ukraine"));
            ddlList.Items.Add(new ListItem("United Kingdom", "United Kingdom"));
            ddlList.Items.Add(new ListItem("United States", "United States"));
            ddlList.Items.Add(new ListItem("Uruguay", "Uruguay"));
            ddlList.Items.Add(new ListItem("Uzbekistan", "Uzbekistan"));
            ddlList.Items.Add(new ListItem("Vanuatu", "Vanuatu"));
            ddlList.Items.Add(new ListItem("Venezuela, Bolivarian Republic of", "Venezuela, Bolivarian Republic of"));
            ddlList.Items.Add(new ListItem("Viet Nam", "Viet Nam"));
            ddlList.Items.Add(new ListItem("Virgin Islands, U.S.", "Virgin Islands, U.S."));
            ddlList.Items.Add(new ListItem("Wallis and Futuna", "Wallis and Futuna"));
            ddlList.Items.Add(new ListItem("Western Sahara", "Western Sahara"));
            ddlList.Items.Add(new ListItem("Yemen", "Yemen"));
            ddlList.Items.Add(new ListItem("Zambia", "Zambia"));
            ddlList.Items.Add(new ListItem("Zimbabwe", "Zimbabwe"));
        }
        /******************************** #  Generate Random No # **********************************/
        public static string IntRandomNumber(int noOfChar)
        {
            var chars = "123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, noOfChar)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        /*********************** Filling DropDowns With Database  ***************************************/

        public static void FillState(DropDownList ddlocationId)
        {
            //var objSQL = new SQLUtility();
            //var dt = objSQL.SP_GetDataTable("usp_statelist");
            //ddlocationId.DataSource = dt;
            //ddlocationId.DataTextField = "State";
            //ddlocationId.DataValueField = "StateId";
            //ddlocationId.DataBind();
            //ddlocationId.Items.Insert(0, new ListItem("-- Select State --", "0"));
        }

        //public static void FillLocation(DropDownList ddl,int stateId)
        //{
        //    var lstLocation = locationRepository.LocationList(1, stateId);
        //    ddl.DataSource = lstLocation;
        //    ddl.DataTextField = "locationName";
        //    ddl.DataValueField = "LocationId";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem("Select", ""));
        //}

        //public static void FillStateWiselocation(DropDownList ddlDealerlocation)
        //{
        //    SQLUtility objSQL = new SQLUtility();
        //    DataTable dt = objSQL.SP_GetDataTable("usp_StateWiselocationlist");
        //    ddlDealerlocation.DataSource = dt;
        //    ddlDealerlocation.DataTextField = "locationName";
        //    ddlDealerlocation.DataValueField = "StateId";
        //    ddlDealerlocation.DataBind();
        //    ddlDealerlocation.Items.Insert(0, new ListItem(" --Select location-- ", "0"));
        //}

        //public static void FillState2(DropDownList ddlList)
        //{
        //    SQLUtility objSQL = new SQLUtility();
        //    DataTable dt = objSQL.SP_GetDataTable("usp_List");
        //    ddlList.DataSource = dt;
        //    ddlList.DataTextField = "StateName";
        //    ddlList.DataValueField = "StateCode";
        //    ddlList.DataBind();
        //    ddlList.Items.Insert(0, new ListItem("select", ""));
        //}

        //public static void FillCategory(DropDownList ddlList)
        //{
        //    ddlList.DataSource = CategoryRepository.CategoryList(1);
        //    ddlList.DataTextField = "CategoryName";
        //    ddlList.DataValueField = "CategoryId";
        //    ddlList.DataBind();
        //    ddlList.Items.Insert(0, new ListItem("-- Select Category --", "0"));
        //}
        //public static void FillModel(DropDownList ddlList)
        //{
        //    ddlList.DataSource = ModelRepository.ModelList(1);
        //    ddlList.DataTextField = "ModelName";
        //    ddlList.DataValueField = "ModelId";
        //    ddlList.DataBind();
        //    ddlList.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}
        //public static void FillModel(DropDownList ddlList, int categoryId)
        //{
        //    ddlList.DataSource = ModelRepository.ModelList(1, categoryId);
        //    ddlList.DataTextField = "ModelName";
        //    ddlList.DataValueField = "ModelId";
        //    ddlList.DataBind();
        //    ddlList.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}
        //public static void FillColor(CheckBoxList chkList)
        //{
        //    chkList.DataSource = ColorRepository.ColorList(1);
        //    chkList.DataTextField = "ColorCode";
        //    chkList.DataValueField = "ColorId";
        //    chkList.DataBind();
            
        //}

        //public static void FillUserCategory(DropDownList ddlcat)
        //{
        //    ddlcat.DataSource = CategoryRepository.CategoryList(1);
        //    ddlcat.DataTextField = "CategoryName";
        //    ddlcat.DataValueField = "CategoryName";
        //    ddlcat.DataBind();
        //    ddlcat.Items.Insert(0, new ListItem("-- Select category --", "0"));
        //}

        
          

       
        /*********************** Filling DropDowns With Dynamic Values  ***************************************/
        public static void FillYear(DropDownList ddlList, int iStart, int iEnd)
        {
            for (int i = iStart; i <= iEnd; i++)
                ddlList.Items.Add((new ListItem(i.ToString(), i.ToString())));
            ddlList.Items.Insert(0, new ListItem("Year", "0"));
        }
        public static void FillNext15Year(DropDownList ddlList)
        {
            for (int i = DateTime.Now.Year; i <= (DateTime.Now.Year + 15); i++)
                ddlList.Items.Add((new ListItem(i.ToString(), i.ToString())));
            ddlList.Items.Insert(0, new ListItem("Year", "0"));
        }

        public static void LoadDDL(DropDownList ddList, int iCount, int iStart)
        {
            for (int i = iStart; i <= iCount; i++)
            {
                ddList.Items.Add((new ListItem(i.ToString(), i.ToString())));
            }
        }
        #endregion
    }
}