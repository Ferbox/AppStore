namespace identity1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Feedbacks", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.Feedbacks", "UserId");
            DropColumn("dbo.Orders", "UserId");
            RenameColumn(table: "dbo.Feedbacks", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Feedbacks", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Feedbacks", "UserId");
            CreateIndex("dbo.Orders", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedbacks", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Feedbacks", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.Feedbacks", "User_Id");
        }
    }
}
