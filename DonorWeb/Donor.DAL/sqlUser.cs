using Donor.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Donor.DAL
{
    /// <summary>
    /// Summary description for sqlUser
    /// </summary>
    public class sqlUser
    {
        private SQLUtility objSql = new SQLUtility();
        // SqlDataReader dr;
        private string spName;

        
        #region "Constructor"
        public sqlUser()
        {
            spName = "usp_User";
        }
        #endregion

        #region "Method Section"

        /// <summary>
        /// Get and Set Login Validate
        /// </summary>
        /// <returns></returns>
        public clsUser UserLoginValidate(string loginId, string loginPwd)
        {
            var objuser = new clsUser();
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@LoginId", loginId),
                new SqlParameter("@LoginPwd", loginPwd),
                new SqlParameter("@QueryType", 1)
            };
            using (SqlDataReader dr = objSql.SP_GetDataReader(spName, sqlParameters))
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        objuser.UserId = Convert.ToInt32(dr["UserId"]);
                        objuser.UserName = Convert.ToString(dr["UserName"]);
                        objuser.EmailId = Convert.ToString(dr["EmailId"]);
                        objuser.LoginId = Convert.ToString(dr["LoginId"]);
                        objuser.Status = Convert.ToInt32(dr["Status"]);
                        objuser.TypeId = Convert.ToInt32(dr["TypeId"]);
                    }
                }
                dr.Close();
            }
            objSql.CloseConnection();
            objSql.DisposeConnection();
            return objuser;
        }

        public bool CheckUserExits(int userId, string loginId)
        {
            bool flag = false;
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@LoginId", loginId),
                new SqlParameter("@QueryType", 2)
            };

            int total = Convert.ToInt32(objSql.ExecuteSP_NonQuery(spName, sqlParameters));
            if (total > 0)
                flag = true;

            return flag;
        }

        /// <summary>
        /// Get User Details By User Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public clsUser UserDetails(int userId)
        {
            var objUser = new clsUser();
            SqlParameter[] selectParam =
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@QueryType", 3)
            };

            using (SqlDataReader dr = objSql.SP_GetDataReader(spName, selectParam))
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        objUser.UserId = Convert.ToInt32(dr["UserId"]);
                        objUser.UserName = Convert.ToString(dr["UserName"]);
                        objUser.EmailId = Convert.ToString(dr["EmailId"]);
                        objUser.LoginId = Convert.ToString(dr["LoginId"]);
                        objUser.LoginPwd = Convert.ToString(dr["LoginPwd"]);
                        objUser.Status = Convert.ToInt32(dr["Status"]);
                        objUser.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        objUser.TypeId = Convert.ToInt32(dr["TypeId"]);
                    }
                }
                dr.Close();
            }

            objSql.CloseConnection();
            objSql.DisposeConnection();
            return objUser;
        }

        /// <summary>
        /// Add/Update User Details
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public bool UserAddUpdate(clsUser objUser)
        {
            bool flag = false;
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@QueryType", 4),
                new SqlParameter("@UserId", objUser.UserId),
                new SqlParameter("@UserName", objUser.UserName),
                new SqlParameter("@EmailId", objUser.EmailId),
                new SqlParameter("@LoginId", objUser.LoginId),
                new SqlParameter("@LoginPwd", objUser.LoginPwd),
                new SqlParameter("@Status", objUser.Status),
                new SqlParameter("@TypeId", objUser.TypeId)
            };

            int iRow = objSql.ExecuteSP_NonQuery(spName, sqlParameters);
            if (iRow > 0)
                flag = true;

            return flag;
        }

        /// <summary>
        /// Delete User Information By User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UserDelete(int userId)
        {
            bool flag = false;
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@QueryType", 5)
            };

            int iRow = objSql.ExecuteSP_NonQuery(spName, sqlParameters);
            if (iRow > 0)
                flag = true;

            return flag;
        }

        /// <summary>
        /// Get User List 
        /// </summary>
        /// <returns></returns>
        public List<clsUser> UserList()
        {
            var lstUser = new List<clsUser>();
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@QueryType", 6)
            };
            using (SqlDataReader dr = objSql.SP_GetDataReader(spName, sqlParameters))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var objUser = new clsUser();
                        objUser.UserId = Convert.ToInt32(dr["UserId"]);
                        objUser.UserName = Convert.ToString(dr["UserName"]);
                        objUser.EmailId = Convert.ToString(dr["EmailId"]);
                        objUser.LoginId = Convert.ToString(dr["LoginId"]);
                        objUser.LoginPwd = Convert.ToString(dr["LoginPwd"]);
                        objUser.Status = Convert.ToInt32(dr["Status"]);
                        objUser.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        objUser.TypeId = Convert.ToInt32(dr["TypeId"]);
                        lstUser.Add(objUser);
                    }
                }
                dr.Close();
            }
            objSql.CloseConnection();
            objSql.DisposeConnection();
            
            return lstUser;
        }

        /// <summary>
        /// Get User List With Paged
        /// </summary>
        /// <returns></returns>
        public List<clsUser> UserListPaged(bool? status, int startPage, int pageLength, out int noOfPages,
            out int totalRecords)
        {
            var lstUser = new List<clsUser>();
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@StartPage", startPage),
                new SqlParameter("@PageLength", pageLength),
                new SqlParameter("@noOfPages", noOfPages = 0) {Direction = ParameterDirection.Output},
                new SqlParameter("@TotalRecords", totalRecords = 0) {Direction = ParameterDirection.Output},
            };
            using (SqlDataReader dr = objSql.SP_GetDataReader("usp_GetUsersPaged", sqlParameters))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var objUser = new clsUser();
                        objUser.UserId = Convert.ToInt32(dr["UserId"]);
                        objUser.UserName = Convert.ToString(dr["UserName"]);
                        objUser.EmailId = Convert.ToString(dr["EmailId"]);
                        objUser.LoginId = Convert.ToString(dr["LoginId"]);
                        objUser.LoginPwd = Convert.ToString(dr["LoginPwd"]);
                        objUser.Status = Convert.ToInt32(dr["Status"]);
                        objUser.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        objUser.TypeId = Convert.ToInt32(dr["TypeId"]);
                        lstUser.Add(objUser);
                    }
                }
                dr.Close();
            }
            objSql.CloseConnection();
            objSql.DisposeConnection();
            noOfPages = Convert.ToInt32(sqlParameters[3].Value);
            totalRecords = Convert.ToInt32(sqlParameters[4].Value);
            return lstUser;
        }

        
        #endregion
    }
}