namespace identity1.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "FeedbackId", "dbo.Feedbacks");
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.Images", new[] { "FeedbackId" });
            DropPrimaryKey("dbo.Images");
            CreateTable(
                "dbo.ImageofFeedbacks",
                c => new
                    {
                        ImageofFeedbackId = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        FeedbackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageofFeedbackId)
                .ForeignKey("dbo.Feedbacks", t => t.FeedbackId, cascadeDelete: true)
                .Index(t => t.FeedbackId);
            
            CreateTable(
                "dbo.ImageOfProducts",
                c => new
                    {
                        ImageOfProductId = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ImageOfProductId);
            
            AddColumn("dbo.Images", "ImageOfProduct_ImageOfProductId", c => c.Int());
            AlterColumn("dbo.Images", "ImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Images", "ProductId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Images", new[] { "ImageId", "ProductId" });
            CreateIndex("dbo.Images", "ProductId");
            CreateIndex("dbo.Images", "ImageOfProduct_ImageOfProductId");
            AddForeignKey("dbo.Images", "ImageOfProduct_ImageOfProductId", "dbo.ImageOfProducts", "ImageOfProductId");
            AddForeignKey("dbo.Images", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            DropColumn("dbo.Images", "Name");
            DropColumn("dbo.Images", "Path");
            DropColumn("dbo.Images", "FeedbackId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "FeedbackId", c => c.Int());
            AddColumn("dbo.Images", "Path", c => c.String());
            AddColumn("dbo.Images", "Name", c => c.String());
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Images", "ImageOfProduct_ImageOfProductId", "dbo.ImageOfProducts");
            DropForeignKey("dbo.ImageofFeedbacks", "FeedbackId", "dbo.Feedbacks");
            DropIndex("dbo.Images", new[] { "ImageOfProduct_ImageOfProductId" });
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.ImageofFeedbacks", new[] { "FeedbackId" });
            DropPrimaryKey("dbo.Images");
            AlterColumn("dbo.Images", "ProductId", c => c.Int());
            AlterColumn("dbo.Images", "ImageId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Images", "ImageOfProduct_ImageOfProductId");
            DropTable("dbo.ImageOfProducts");
            DropTable("dbo.ImageofFeedbacks");
            AddPrimaryKey("dbo.Images", "ImageId");
            CreateIndex("dbo.Images", "FeedbackId");
            CreateIndex("dbo.Images", "ProductId");
            AddForeignKey("dbo.Images", "ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Images", "FeedbackId", "dbo.Feedbacks", "FeedbackId");
        }
    }
}
