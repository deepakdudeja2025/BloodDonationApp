
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donor.BO
{
    public class clsUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string LoginId { get; set; }
        public string LoginPwd { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAnonymous { get; set; }
        public int TypeId { get; set; }

        public string StatusTxt
        {
            get { return Status == 1 ? "Yes" : "No"; }
        }
    }
}