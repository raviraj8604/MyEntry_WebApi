using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
  public class OffsetPaperTypeModel
    {
        public int PaperTypeID { get; set; }

        [Required(ErrorMessage = "Please Enter Paper Type Code")]
        public string PaperTypeCode { get; set; }

        [Required(ErrorMessage = "Please Enter Paper Type Name")]
        public string PaperTypeName { get; set; }
        public string PaperTypeDesc { get; set; }
        public bool Active { get; set; }
        public int UserID { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedByName { get; set; }
        public string ModifyDate { get; set; }


    }
}
