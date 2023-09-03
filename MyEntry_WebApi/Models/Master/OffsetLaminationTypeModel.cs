using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
   public  class OffsetLaminationTypeModel
    {
        public int LaminationTypeID { get; set; }
        [Required(ErrorMessage = "Please Enter Lamination Type Code")]
        public string LaminationTypeCode { get; set; }
        [Required(ErrorMessage = "Please Enter Lamination Type Name")]
        public string LaminationTypeName { get; set; }
        public string LaminationTypeDesc { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifyBy { get; set; }
        public string ModifyDate { get; set; }
        public int UserID { get; set; }
    }
}
