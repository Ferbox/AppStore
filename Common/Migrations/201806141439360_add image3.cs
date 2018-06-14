namespace identity1.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimage3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Images");
            AlterColumn("dbo.Images", "ImageId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Images", "ImageId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Images");
            AlterColumn("dbo.Images", "ImageId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Images", new[] { "ImageId", "ProductId" });
        }
    }
}
