using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;


namespace Garage_2._0.DataAccessLayer
{
    public class RegisterContext : DbContext
    {
        public RegisterContext() : base("DefaultConnection2") {
           
        }
        
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }

      
    }

}