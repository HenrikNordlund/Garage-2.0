using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class MemberParkedVehicleContext : DbContext
    {
        public MemberParkedVehicleContext() : base("name=MemberParkedVehicleContext")
        {
        }

       public DbSet<Member> Members { get; set; }

       public DbSet<ParkedVehicle> ParkedVehicles { get; set; }


    }
}