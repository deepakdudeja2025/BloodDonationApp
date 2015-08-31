using Donor.BO;
using Donor.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI.WebControls;


namespace Donor.BAL
{
    public class UserRepository
    {
        public static clsUser UserLoginValidate(string loginId, string loginPwd)
        {
            var objUser= new sqlUser();
            return objUser.UserLoginValidate(loginId, loginPwd);
        }
        public static bool CheckUserExits(int userId, string loginId)
        {
            var objUser = new sqlUser();
            return objUser.CheckUserExits(userId, loginId);
        }
        public static clsUser UserDetails(int userId)
        {
            var objUser = new sqlUser();
            return objUser.UserDetails(userId);
        }
        public static bool UserAddUpdate(clsUser userInfo)
        {
            var objUser = new sqlUser();
            return objUser.UserAddUpdate(userInfo);
        }
        public static bool UserDelete(int userId)
        {
            var objUser = new sqlUser();
            return objUser.UserDelete(userId);
        }
        public static List<clsUser> UserList()
        {
            var objUser = new sqlUser();
            return objUser.UserList();

        }
        public static List<clsUser> UserListPaged(int startPage, int pageLength, out int noOfPages, out int totalRecords)
        {
            return UserListPaged(null, startPage, pageLength, out noOfPages, out totalRecords);
        }
        public static List<clsUser> UserListPaged(bool? status, int startPage, int pageLength, out int noOfPages,out int totalRecords)
        {
            var objUser = new sqlUser();
            return objUser.UserListPaged(status, startPage, pageLength, out noOfPages, out totalRecords);
        }
        
    }
}