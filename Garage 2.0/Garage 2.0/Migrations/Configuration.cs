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
            var members = new[]
            {
                 new Models.Member { MemberSignum = "ÅKE001", FirstName = "Åke", LastName = "Elweskiöld" },
                 new Models.Member { MemberSignum = "HEN001", FirstName = "Henrik", LastName = "Nordlund" },
                 new Models.Member { MemberSignum = "HEN002", FirstName = "Henrik", LastName = "Gahn" }
            };

            context.Members.AddOrUpdate(
             v => v.MemberSignum, members
                 );

            context.SaveChanges();




            var VehicleTypes = new[]
            {
                 new Models.VehicleType { FordonsType = "Car" },
                 new Models.VehicleType { FordonsType = "Bus" },
                 new Models.VehicleType { FordonsType = "Lorry" },
                 new Models.VehicleType { FordonsType = "MC" },
                 new Models.VehicleType { FordonsType = "Bike" }
            };

            context.VehicleTypes.AddOrUpdate(
             v => v.FordonsType, VehicleTypes
                  );

            context.SaveChanges();


            context.ParkedVehicles.AddOrUpdate(
                v => v.RegNo,

                new Models.ParkedVehicle { MemberId = members[0].Id, VehicleTypeId = VehicleTypes[0].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC123", Color = "Red", Brand = "BMW", Model = "M23", NoOfWheels = 4 },
                new Models.ParkedVehicle { MemberId = members[1].Id, VehicleTypeId = VehicleTypes[0].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC234", Color = "Black", Brand = "Opel", Model = "MPV", NoOfWheels = 4 },
                new Models.ParkedVehicle { MemberId = members[2].Id, VehicleTypeId = VehicleTypes[0].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC345", Color = "White", Brand = "Fiat", Model = "ZZ", NoOfWheels = 4 },
                new Models.ParkedVehicle { MemberId = members[1].Id, VehicleTypeId = VehicleTypes[0].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC456", Color = "Green", Brand = "WW", Model = "B2", NoOfWheels = 4 },
                new Models.ParkedVehicle { MemberId = members[1].Id, VehicleTypeId = VehicleTypes[0].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "YYY456", Color = "Green", Brand = "Citroen", Model = "X", NoOfWheels = 4  },
                new Models.ParkedVehicle { MemberId = members[0].Id, VehicleTypeId = VehicleTypes[3].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "YYY444", Color = "Gray", Brand = "BMV", Model = "DD", NoOfWheels = 2  },
                new Models.ParkedVehicle { MemberId = members[2].Id, VehicleTypeId = VehicleTypes[3].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "YYY443", Color = "Silver", Brand = "Peugeot", Model = "RR", NoOfWheels =2 }, 
                new Models.ParkedVehicle { MemberId = members[0].Id, VehicleTypeId = VehicleTypes[1].Id, CheckInTime = new DateTime(2018, 2, 9, 8, 30, 0), RegNo = "ABC222", Color = "Red", Brand = "BMW", Model = "M3", NoOfWheels = 6 }

                );

           





            context.SaveChanges();
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
