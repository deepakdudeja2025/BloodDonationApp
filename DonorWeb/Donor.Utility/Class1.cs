using Donor.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Donor.Utility
{
    public static class clsCookies
    {
        public static void CookieCreateSession(clsUser AdminUser)
        {
            string strValue = HttpContext.Current.Session.SessionID.ToString() + "#" + AdminUser.UserId.ToString() +
                              "#" + AdminUser.TypeId.ToString() + "#" + AdminUser.UserName.ToString();
            HttpCookie LoginCookies = new HttpCookie("LoginCookies");
            LoginCookies.Value = strValue;
            LoginCookies.Expires = DateTime.Now.AddHours(2);
            HttpContext.Current.Response.Cookies.Add(LoginCookies);
        }

        public static void CookieCheckSession()
        {
            if (HttpContext.Current.Request.Cookies["LoginCookies"] != null)
            {
                //string strValue = HttpContext.Current.Request.Cookies["LoginCookies"].Value;
                //string[] sValue = strValue.Split('#');
                //if (string.IsNullOrEmpty(strValue))
                //    HttpContext.Current.Response.Redirect("logout.aspx");
                //else
                //    HttpContext.Current.Response.Cookies["LoginCookies"].Expires = DateTime.Now.AddHours(1);
            }
            else
                HttpContext.Current.Response.Redirect("logout.aspx");
        }

        public static void CookieGetSession(clsUser AdminUser)
        {
            if (HttpContext.Current.Request.Cookies["LoginCookies"] != null)
            {
                string strValue = HttpContext.Current.Request.Cookies["LoginCookies"].Value;
                string[] sValue = strValue.Split('#');
                if (sValue.Length > 3)
                {
                    AdminUser.UserId = Convert.ToInt32(sValue[1]);
                    AdminUser.TypeId = Convert.ToInt32(sValue[2]);
                    AdminUser.UserName = sValue[3].ToString();

                }
                else
                    HttpContext.Current.Response.Redirect("logout.aspx");
            }
            else
                HttpContext.Current.Response.Redirect("logout.aspx");
        }

        public static int CookieGetId()
        {
            int intId = 0;
            if (HttpContext.Current.Request.Cookies["LoginCookies"] != null)
            {
                string strValue = HttpContext.Current.Request.Cookies["LoginCookies"].Value;
                string[] sValue = strValue.Split('#');
                if (sValue.Length > 3)
                    intId = Convert.ToInt32(sValue[1]);
            }
            return intId;
        }

        public static void CookieDelete()
        {
            if (HttpContext.Current.Request.Cookies["LoginCookies"] != null)
            {
                HttpContext.Current.Response.Cookies["LoginCookies"].Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies["LoginCookies"].Value = null;
            }
        }
    }
}
