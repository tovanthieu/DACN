namespace DACSWebCaFeSunDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateall : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Adv", newName: "Adv");
            RenameTable(name: "dbo.tb_Category", newName: "Category");
            RenameTable(name: "dbo.tb_News", newName: "News");
            RenameTable(name: "dbo.tb_Posts", newName: "Posts");
            RenameTable(name: "dbo.tb_Contact", newName: "Contact");
            RenameTable(name: "dbo.tb_OrderDetail", newName: "OrderDetail");
            RenameTable(name: "dbo.tb_Order", newName: "Order");
            RenameTable(name: "dbo.tb_Product", newName: "Product");
            RenameTable(name: "dbo.tb_ProductCategory", newName: "ProductCategory");
            RenameTable(name: "dbo.tb_ProductImage", newName: "ProductImage");
            RenameTable(name: "dbo.th_Review", newName: "Review");
            RenameTable(name: "dbo.tb_Wishlist", newName: "Wishlist");
            RenameTable(name: "dbo.tb_Subscribe", newName: "Subscribe");
            RenameTable(name: "dbo.tb_SystemSetting", newName: "SystemSetting");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SystemSetting", newName: "tb_SystemSetting");
            RenameTable(name: "dbo.Subscribe", newName: "tb_Subscribe");
            RenameTable(name: "dbo.Wishlist", newName: "tb_Wishlist");
            RenameTable(name: "dbo.Review", newName: "th_Review");
            RenameTable(name: "dbo.ProductImage", newName: "tb_ProductImage");
            RenameTable(name: "dbo.ProductCategory", newName: "tb_ProductCategory");
            RenameTable(name: "dbo.Product", newName: "tb_Product");
            RenameTable(name: "dbo.Order", newName: "tb_Order");
            RenameTable(name: "dbo.OrderDetail", newName: "tb_OrderDetail");
            RenameTable(name: "dbo.Contact", newName: "tb_Contact");
            RenameTable(name: "dbo.Posts", newName: "tb_Posts");
            RenameTable(name: "dbo.News", newName: "tb_News");
            RenameTable(name: "dbo.Category", newName: "tb_Category");
            RenameTable(name: "dbo.Adv", newName: "tb_Adv");
        }
    }
}
