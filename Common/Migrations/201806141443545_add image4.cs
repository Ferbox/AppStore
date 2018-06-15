namespace identity1.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimage4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ImageOfProduct_ImageOfProductId", "dbo.ImageOfProducts");
            DropIndex("dbo.Images", new[] { "ImageOfProduct_ImageOfProductId" });
            RenameColumn(table: "dbo.Images", name: "ImageOfProduct_ImageOfProductId", newName: "ImageOfProductId");
            DropPrimaryKey("dbo.Images");
            AlterColumn("dbo.Images", "ImageOfProductId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Images", new[] { "ImageOfProductId", "ProductId" });
            CreateIndex("dbo.Images", "ImageOfProductId");
            AddForeignKey("dbo.Images", "ImageOfProductId", "dbo.ImageOfProducts", "ImageOfProductId", cascadeDelete: true);
            DropColumn("dbo.Images", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Images", "ImageOfProductId", "dbo.ImageOfProducts");
            DropIndex("dbo.Images", new[] { "ImageOfProductId" });
            DropPrimaryKey("dbo.Images");
            AlterColumn("dbo.Images", "ImageOfProductId", c => c.Int());
            AddPrimaryKey("dbo.Images", "ImageId");
            RenameColumn(table: "dbo.Images", name: "ImageOfProductId", newName: "ImageOfProduct_ImageOfProductId");
            CreateIndex("dbo.Images", "ImageOfProduct_ImageOfProductId");
            AddForeignKey("dbo.Images", "ImageOfProduct_ImageOfProductId", "dbo.ImageOfProducts", "ImageOfProductId");
        }
    }
}
