using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEntry_WebApi.Models
{
    public class UserModel
    {

      
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string UserType { get; set; }
        public int UserTypeID { get; set; }
        public string UserStatus { get; set; }
        public string RemoteHostIP { get; set; }
        public string RemoteHostName { get; set; }
        public string UserTypeName { get; set; }
        public int DivisionID { get; set; }
        public bool MultiProductJobs { get; set; }
        public string CompanyLogo { get; set; }

    }
}