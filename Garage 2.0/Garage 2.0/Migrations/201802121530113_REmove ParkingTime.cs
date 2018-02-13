namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REmoveParkingTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "ParkingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "ParkingTime", c => c.DateTime(nullable: false));
        }
    }
}
