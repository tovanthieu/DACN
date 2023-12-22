namespace DACSWebCaFeSunDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeliveryStatusOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "DeliveryStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "DeliveryStatus");
        }
    }
}
