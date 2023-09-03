using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.CustomerManagement
{
   public class UpdateCustoemerPrice
    {

        public enum enumMode
        {
            UpdatePrice = 3,
            InsertPrice = 4,
        }
        public enumMode Mode { get; set; }
        public int CustomerID { get; set; }
        public int CustRateID { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string WefDate { get; set; }
        public string PreviousDate { get; set; }
        public string strPaperPrice { get; set; }
        public string strCoverPrice { get; set; }
        public string strItemPrice { get; set; }
        public string strAccessoryPrice { get; set; }

    }
}
