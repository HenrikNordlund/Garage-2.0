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
        public VehicleType Type { get; set; }

        [Required]
        public string RegNo { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NoOfWheels { get; set; }
    }
}