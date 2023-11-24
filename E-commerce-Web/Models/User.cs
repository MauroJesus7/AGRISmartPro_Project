using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace AGRISmartPro.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Required filed")]
        [MaxLength(50)]
        [Display(Name ="Email")]
        [Index("User_UserName_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required filed")]
        [MaxLength(50)]
        [Index("User_Phone_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Required filed")]
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Display(Name = "Report Code")]
        public int Dis_ReportId { get; set; }

        [Display(Name = "User")] 
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public virtual Crop Crops { get; set; }
        public virtual Disease Diseases { get; set; }  
        public virtual ICollection<DiseaseReport> DiseasesReport { get; set; }
        public virtual ICollection<UserTeam> UserTeams { get; set; }


    }
}