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

                new Models.ParkedVehicle { RegNo = "ABC123", Type = Models.VehicleType.Combi, Color = "Red", Brand = "BMW", Model = "M23", NoOfWheels = 4 },
                new Models.ParkedVehicle { RegNo = "ABC234", Type = Models.VehicleType.Sedan, Color = "Black", Brand = "Opel", Model = "MPV", NoOfWheels = 4 },
                new Models.ParkedVehicle { RegNo = "ABC345", Type = Models.VehicleType.SUV, Color = "White", Brand = "Fiat", Model = "ZZ", NoOfWheels = 4 },
                new Models.ParkedVehicle { RegNo = "ABC456", Type = Models.VehicleType.Combi, Color = "Green", Brand = "WW", Model = "B2", NoOfWheels = 4 },
                new Models.ParkedVehicle { RegNo = "YYY456", Type = Models.VehicleType.Sedan, Color = "Green", Brand = "Citroen", Model = "X", NoOfWheels = 4 },
                new Models.ParkedVehicle { RegNo = "YYY444", Type = Models.VehicleType.MC, Color = "Gray", Brand = "BMV", Model = "DD", NoOfWheels = 2 },
                new Models.ParkedVehicle { RegNo = "YYY443", Type = Models.VehicleType.Vespa, Color = "Silver", Brand = "Peugeot", Model = "RR", NoOfWheels = 2 }, 
                new Models.ParkedVehicle { RegNo = "ABC222", Type = Models.VehicleType.Combi, Color = "Red", Brand = "BMW", Model = "M3", NoOfWheels = 6 }

                );


            context.SaveChanges();
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
