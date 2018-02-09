namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage_2._0.DataAccessLayer.RegisterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage_2._0.DataAccessLayer.RegisterContext context)
        {

            context.ParkedVehicles.AddOrUpdate(
                v => v.Id,

                new Models.ParkedVehicle { RegNo = "ABC123", Type = 1, Color = "Red", Brand = "BMW", Model = "MC", NoOfWheels = 2 },
                new Models.ParkedVehicle { RegNo = "ABC234", Type = 1, Color = "Black", Brand = "Opel", Model = "MPV", NoOfWheels = 4 },
                new Models.ParkedVehicle { RegNo = "ABC345", Type = 2, Color = "White", Brand = "Fiat", Model = "Jeep", NoOfWheels = 4 },
                new Models.ParkedVehicle { RegNo = "ABC456", Type = 3, Color = "Green", Brand = "Citroen", Model = "Buss", NoOfWheels = 8 }

                );


            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
