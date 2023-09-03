using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.CustomerManagement
{
   public class CustomerAddressModel
    {
        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        public int AddressType { get; set; }

        [Required(ErrorMessage = "Please Enter Address Line 1")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        public int StateID { get; set; }
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        [Required(ErrorMessage ="Please Enter Contact Person Name")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Person Number")]
        public string ContactNo { get; set; }
        public bool DefaultAddress { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifyBy { get; set; }
        public string ModifiedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Pin Code")]
        public string PinCode { get; set; }
        public string CustomerName { get; set; }

    }
}
