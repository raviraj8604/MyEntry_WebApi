using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Company
{
   public class CommonModel
    {
        public enum enumMode 
        {
            GetCountry = 1,
            GetState = 2,
            GetStateWithCountry = 3
        }
        public enumMode Mode { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }

    }
}
