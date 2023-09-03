using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
  public class OffsetMachineModel
    {
        public int MachineID { get; set; }
        [Required(ErrorMessage = "Please Select Stage")]
        public int StageID { get; set; }
        [Required(ErrorMessage = "Please Enter Machine Code")]
        public string MachineCode { get; set; }
        [Required(ErrorMessage = "Please Enter Machine Name")]
        public string MachineName { get; set; }
        public string MachineDesc { get; set; }
        public bool Active { get; set; }
        public int UserID { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedByName { get; set; }
        public string StageCode { get; set; }

    }
}
