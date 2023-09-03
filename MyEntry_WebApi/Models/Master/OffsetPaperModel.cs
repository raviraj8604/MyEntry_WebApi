using Prism_Models.Offset;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Models.Master
{
  public  class OffsetPaperModel
    {
        public Mode Mode { get; set; }
        public int PaperID { get; set; }

        [Required(ErrorMessage = "Please Select Paper Location")]
        public int PaperLocation { get; set; }

        [Required(ErrorMessage = "Please Enter Paper Code")]
        public string PaperCode { get; set; }

        [Required(ErrorMessage = "Please Enter Paper Name")]
        public string PaperName { get; set; }
        public string PaperQuality { get; set; }

        [Required(ErrorMessage = "Please Enter Paper GSM")]
        public int? PaperGSM { get; set; }

        public int PaperGSMTo { get; set; }

        [Required(ErrorMessage = "Please Select Paper Type")]
        public int PaperTypeID { get; set; }
        public string PaperTypeName { get; set; }

        [Required(ErrorMessage = "Please Select Paper Finish")]
        public int PaperFinishID { get; set; }

        public string FinishName { get; set; }

        [Required(ErrorMessage = "Please Select Paper Division")]
        public int PaperDivision { get; set; }
        public decimal PaperWeight { get; set; }
        //Inch
        public string PaperSize { get; set; }

        [Required(ErrorMessage = "Please Enter Width")]
        public decimal? PaperWidth { get; set; }

        [Required(ErrorMessage = "Please Enter Height")]
        public decimal? PaperHeight { get; set; }
        public decimal? PaperCaliper { get; set; }

        //MM
        public string PaperSizeMM { get; set; }

        [Required(ErrorMessage = "Please Width MM")]
        public decimal? PaperWidthMM { get; set; }

        [Required(ErrorMessage = "Please Height MM")]
        public decimal? PaperHeightMM { get; set; }


        [Required(ErrorMessage = "Please Enter Balance Qty")]
        public decimal? BalanceQty { get; set; }

        public string MOnBundel { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyDate { get; set; }
        public string CreatedByName { get; set; }
        public int UserID { get; set; }
        public string Remarks { get; set; }
        public bool Active { get; set; }


      


    }

}
