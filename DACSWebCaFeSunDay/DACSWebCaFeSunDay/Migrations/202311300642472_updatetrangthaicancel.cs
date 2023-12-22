namespace DACSWebCaFeSunDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetrangthaicancel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Cancelled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Order", "CancelledMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "CancelledMessage");
            DropColumn("dbo.Order", "Cancelled");
        }
    }
}
