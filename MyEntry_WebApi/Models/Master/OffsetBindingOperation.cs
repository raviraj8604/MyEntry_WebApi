using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
  public  class OffsetBindingOperationModel
    {

        public int BindingOperationID { get; set; }

        [Required(ErrorMessage = "Please Enter Operation Code")]
        public string BindingOperationCode { get; set; }
        [Required(ErrorMessage = "Please Enter Operation Desc")]
        public string BindingOperationDesc { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }

        public int UserID { get; set; }
        public string CreatedByName { get; set; }

    }
}
