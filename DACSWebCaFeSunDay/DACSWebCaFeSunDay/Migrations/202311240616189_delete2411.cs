namespace DACSWebCaFeSunDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete2411 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseHistory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.PurchaseHistory", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PurchaseHistory", new[] { "UserId" });
            DropIndex("dbo.PurchaseHistory", new[] { "ProductId" });
            DropTable("dbo.PurchaseHistory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurchaseHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PurchaseHistory", "ProductId");
            CreateIndex("dbo.PurchaseHistory", "UserId");
            AddForeignKey("dbo.PurchaseHistory", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PurchaseHistory", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
    }
}
