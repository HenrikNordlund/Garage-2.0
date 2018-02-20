using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Registration Number")]
        [ValidateRegNo(ErrorMessage ="Reg number already exists")]
        public string RegNo { get; set; }
        [Required]
        [StringLength(20)]
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Range(1,8)]
        [Display(Name = "Number Of Wheels")]
        public int NoOfWheels { get; set; }
        //public DateTime ParkingTime { get; set; }

        [Display(Name = "Check in time: ")]
        public DateTime CheckInTime { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }

    }
}