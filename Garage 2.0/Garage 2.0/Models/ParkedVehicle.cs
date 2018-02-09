﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string RegNo { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NoOfWheels { get; set; }

    }
}