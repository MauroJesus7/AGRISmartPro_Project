using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AGRISmartPro.Models
{
    public class Crop
    {
        [Key]
        public int CropId { get; set; }

        [Required(ErrorMessage = "Required field...")]
        [Index("Crop_Name_Index", IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
        public virtual ICollection<DiseaseReport> Companies { get; set; }

    }
}