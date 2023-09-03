using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
   public class OffsetColorModel
    {
        public bool Active { get; set; }
        [Required(ErrorMessage = "Please Enter Color Code")]
        public string ColorCode { get; set; }
        public int ColorID { get; set; }
        [Required(ErrorMessage = "Please Enter Color Name")]
        public string ColorName { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifyBy { get; set; }
        public string ModifyDate { get; set; }
        public int UserID { get; set; }
    }
}
