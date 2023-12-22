namespace DACSWebCaFeSunDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateall1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            AlterColumn("dbo.Order", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "UserId");
            AddForeignKey("dbo.Order", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseHistory", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseHistory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Order", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PurchaseHistory", new[] { "ProductId" });
            DropIndex("dbo.PurchaseHistory", new[] { "UserId" });
            DropIndex("dbo.Order", new[] { "UserId" });
            AlterColumn("dbo.Order", "UserId", c => c.String());
            DropTable("dbo.PurchaseHistory");
        }
    }
}
