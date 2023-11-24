using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AGRISmartPro.Models
{
    public class Disease
    {
        [Key]
        public int DiseaseId { get; set; }

        [Required(ErrorMessage = "Required filed")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Select a crop")]
        public int CropId { get; set; }

        public virtual Crop Crop { get; set; }
        public virtual ICollection<DiseaseReport> DiseasesReport { get; set; }

    }
}