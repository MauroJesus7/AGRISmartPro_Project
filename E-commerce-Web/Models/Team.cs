using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AGRISmartPro.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Required field.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must have between 3 and 50 chars")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Created_By { get; set; }

        public virtual ICollection<UserTeam> UserTeams { get; set; }
    }
}