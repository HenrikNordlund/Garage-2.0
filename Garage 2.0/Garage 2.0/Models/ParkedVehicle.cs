using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public enum VehicleType { Sedan, Combi, SUV, MC, Vespa };

    public class ParkedVehicle
    {
        public int Id { get; set; }
        [Required]
        public VehicleType Type { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string RegNo { get; set; }
        [Required]
        [StringLength(20)]
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Range(1,8)]
        [Display(Name = "Number Of Wheels")]
        public int NoOfWheels { get; set; }
    }
}