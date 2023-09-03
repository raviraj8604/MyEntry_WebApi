using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyEntry_WebApi.Models.Company
{
   public class CompanyAccountModel
    {
        public int CompanyBankID { get; set; }
    
        public int CompanyID { get; set; }
       
        public int BankID { get; set; }
        public string BankName { get; set; }


        public string AccountNo { get; set; }


        public string AccountHolderName { get; set; }
        public string IFSCCode { get; set; }

        public string Address { get; set; }
        public bool Default { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
    }
}
