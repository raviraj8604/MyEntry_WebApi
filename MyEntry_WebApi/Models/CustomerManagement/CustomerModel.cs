using Prism_Models.OrchidManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.CustomerManagement
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Please Select Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Code")]
        public string CustomerCode { get; set; }
        public string GSTNo { get; set; }
        public string CinNo { get; set; }
        public string PANNo { get; set; }
        public string TANNo { get; set; }


        [Required(ErrorMessage = "Please Enter Address Line 1")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Pin Code")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        public int StateID { get; set; }
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Select Country ")]
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number ")]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number ")]
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Person")]
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Remarks { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Please Select Wef Date Price")]
        public string WefDatePrice { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string DivisonName { get; set; }
        public string DivisionIds { get; set; }
        public string GetWefDatePrice { get; set; }

        //list for getting records
        public List<Company.CompanyDivisionsModel> DivisionsList { get; set; }
        public List<OrchidPaperTypeModel> OrchidPaperTypeList { get; set; }
        public List<OrchidCoverTypesModel> OrchidCoverList { get; set; }
        public List<OrchidItemsModel> OrchidItemList { get; set; }
        public List<OrchidAccessoriesModel> OrchidAccessoriesList { get; set; }
        //for saving records
        public string CustmerDivisonList { get; set; }
        public string CustmerPeparPrice { get; set; }
        public string CustmerCoverPrice { get; set; }
        public string CustmerItemPrice { get; set; }
        public string CustmerAccessoriesPrice { get; set; }

        //[Required(ErrorMessage = "Please Select Shipment Mode")]
        public int ShipmentModeID { get; set; }

        [Required(ErrorMessage = "Please Enter Payment Variation")]
        public decimal? JobPaymentVariation { get; set; }
        public string InvoiceName { get; set; }

        [Required(ErrorMessage = "Please Enter Contact No")]
        public string ContactNo { get; set; }

        public int MarketingPersonID { get; set; }

        public string MarketingPersonName { get; set; }

        public string ShipmentDetails { get; set; }

    }
}
