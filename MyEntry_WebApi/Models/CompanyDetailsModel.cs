using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEntry_WebApi.Models
{
    public class CompanyDetailsModel
    {
        public string Website { get; set; }
        public string Remarks { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public object LogoPath { get; set; }
        public int StateID1 { get; set; }
        public int CountryID1 { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public int GSTCode { get; set; }
        public object CreatedBy1 { get; set; }
        public DateTime CreatedDate1 { get; set; }
        public string Email2 { get; set; }
        public string Email1 { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string GSTNo { get; set; }
        public string CINNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public object ModifyBy1 { get; set; }
        public string Address3 { get; set; }
        public string PinCode { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string AuthorisedPerson { get; set; }
        public string Designation { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string City { get; set; }
        public DateTime ModifyDate1 { get; set; }
    }
}