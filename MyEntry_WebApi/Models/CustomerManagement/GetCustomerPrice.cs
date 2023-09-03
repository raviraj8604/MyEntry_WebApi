using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.CustomerManagement
{

    public class CustomerDetail
    {
        public int Customerid { get; set; }
        public int CustomerID { get; set; }
        public int CompanyID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string GSTNo { get; set; }
        public object PANNo { get; set; }
        public object TANNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Remarks { get; set; }
        public string Website { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifyBy { get; set; }
        public object ModifyDate { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string DivisonName { get; set; }

        public string WefDatePrice { get; set; }
        public string GetWefDatePrice { get; set; }
    }

    public class CustomerCoverPrice
    {
        public int CoverPriceID { get; set; }
        public int CoverTypeID { get; set; }
        public int CustRateID { get; set; }
        public string CoverTypeCode { get; set; }
        public string CoverTypeName { get; set; }
        public double CoverPrice { get; set; }
        public int SizeID { get; set; }
        public int SizeGroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupSizeNames { get; set; }
        public string HotFolderName { get; set; }
        public double MinCoverPrice { get; set; }

    }

    public class CustomerPaperPrice
    {

        public int PaperPriceID { get; set; }
        public int PaperTypeID { get; set; }
        public int CustRateID { get; set; }
        public string PaperTypeName { get; set; }
        public string PaperTypeCode { get; set; }
        public double PaperPrice { get; set; }
        public int SizeID { get; set; }
        public int SizeGroupID { get; set; }
        public string GroupName { get; set; }

        public string GroupSizeNames { get; set; }
        public string HotFolderName { get; set; }
        public double MinPaperPrice { get; set; }
    }

    public class CustomerAccessoriesPrice
    {
        public int AsscPriceID { get; set; }
        public int AccessoryID { get; set; }
        public int CustRateID { get; set; }
        public string AccessoryName { get; set; }
        public string AccessoryCode { get; set; }
        public double AccessoryPrice { get; set; }
        public int AccessoryType { get; set; }

    }

    public class CustomerItemPrice
    {
        public int ItemPriceID { get; set; }
        public int ItemID { get; set; }
        public int CustRateID { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public double ItemPrice { get; set; }
    }

    public class GetCustomerPrice
    {
        public List<CustomerDetail> CustomerDetails { get; set; }
        public List<CustomerCoverPrice> CustomerCoverPrice { get; set; }
        public List<CustomerPaperPrice> CustomerPaperPrice { get; set; }
        public List<CustomerAccessoriesPrice> CustomerAccessoriesPrice { get; set; }
        public List<CustomerItemPrice> CustomerItemPrice { get; set; }
    }
}
