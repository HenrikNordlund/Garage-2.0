namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNullRegNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "RegNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "RegNo", c => c.String());
        }
    }
}
