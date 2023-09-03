using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
  public class OffsetFinishTypeModel
    {
        public int FinishID { get; set; }
        [Required(ErrorMessage = "Please Enter Finish Code")]
        public string FinishCode { get; set; }
        [Required(ErrorMessage = "Please Enter Finish Name")]
        public string FinishName { get; set; }
        public string FinishDesc { get; set; }
        [Required(ErrorMessage = "Please Select Finish For")]
        public int FinishFor { get; set; }
        public bool Active { get; set; }
        public int UserID { get; set; }
        public string CreatedByName { get; set; }
    }
}
