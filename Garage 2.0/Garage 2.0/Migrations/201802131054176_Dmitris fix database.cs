namespace Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dmitrisfixdatabase : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        RegNo = c.String(nullable: false),
                        Color = c.String(nullable: false, maxLength: 20),
                        Brand = c.String(),
                        Model = c.String(),
                        NoOfWheels = c.Int(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                        CheckInTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
