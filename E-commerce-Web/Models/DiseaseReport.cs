using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AGRISmartPro.Models
{
    public class DiseaseReport
    {
        [Key]
        public int Dis_ReportId { get; set; }
        [Required(ErrorMessage = "Required filed")]
        [MaxLength(50)]
        [Index("DiseaseReport_Code_Index", IsUnique = true)]
        [Display(Name ="Report Code")]
        public string Code { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Status { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Display(Name = "Crop")]
        [Required(ErrorMessage = "Required filed")]
        public int CropId { get; set; }

        [Display(Name = "Disease")]
        [Required(ErrorMessage = "Required filed")]
        public int DiseaseId { get; set; }
        public virtual Crop Crops { get; set; }
        public virtual Disease Diseases { get; set; }
        public virtual User User { get; set; }



    }
}