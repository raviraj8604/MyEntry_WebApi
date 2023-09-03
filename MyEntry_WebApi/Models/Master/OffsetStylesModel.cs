using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
    public class OffsetStylesModel
    {
        public int StyleID { get; set; }
        [Required(ErrorMessage = "Please Enter Style Name")]
        public string StyleName { get; set; }

        [Required(ErrorMessage = "Please Enter Style Code")]
        public string StyleCode { get; set; }
        public string StyleDesc { get; set; }
        public bool Active { get; set; }
        public int UserID { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifyBy { get; set; }
        public string ModifyDate { get; set; }

    }
}
