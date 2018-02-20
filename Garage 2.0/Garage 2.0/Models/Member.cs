using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace Garage_2._0.Models
{
    public class Member
    {

        public int Id { get; set; } 

        [Display(Name = "First Name")]
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Display(Name = "Member Signum")]
        [Required]
        [StringLength(6)]
        public string MemberSignum { get; set; }

        public virtual ICollection<ParkedVehicle> MemberParkedVehicles { get; set; }

    }
}