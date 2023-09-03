using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntry_WebApi.Models.Company
{
   public class BankModel
    {
        public int BankID { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public bool Active { get; set; }
        public bool ISDeleted { get; set; }
    }
}
