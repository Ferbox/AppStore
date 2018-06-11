namespace identity1.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_OrderItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductOrders", new[] { "Order_OrderId" });
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.Orders", "Quantity");
            DropTable("dbo.ProductOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Order_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Order_OrderId });
            
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.OrderItems");
            CreateIndex("dbo.ProductOrders", "Order_OrderId");
            CreateIndex("dbo.ProductOrders", "Product_ProductId");
            AddForeignKey("dbo.ProductOrders", "Order_OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrders", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
