using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
  public class OffsetBindingTypeModel
    {
        public int BindingTypeID { get; set; }

        [Required(ErrorMessage = "Please Enter Binding Type Code")]
        public string BindingTypeCode { get; set; }

        [Required(ErrorMessage = "Please Enter Binding Type Name")]
        public string BindingTypeName { get; set; }
        public string BindingTypeDesc { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }

    }
}
