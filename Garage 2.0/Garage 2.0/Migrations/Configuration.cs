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
                v => v.RegNo,

                new Models.ParkedVehicle {CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC123", Type = Models.VehicleType.Combi, Color = "Red", Brand = "BMW", Model = "MC", NoOfWheels = 2 },
                new Models.ParkedVehicle {CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC234", Type = Models.VehicleType.Sedan, Color = "Black", Brand = "Opel", Model = "MPV", NoOfWheels = 4 },
                new Models.ParkedVehicle {CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC345", Type = Models.VehicleType.SUV, Color = "White", Brand = "Fiat", Model = "Jeep", NoOfWheels = 4 },
                new Models.ParkedVehicle { CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0),  RegNo = "ABC456", Type = Models.VehicleType.Vespa, Color = "Green", Brand = "Citroen", Model = "Buss", NoOfWheels = 8 }

                );


            context.SaveChanges();
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
