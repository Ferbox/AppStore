namespace identity1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Feedbacks", name: "ApplicationUser_Id", newName: "User_Id");
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            AddColumn("dbo.Feedbacks", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Feedbacks", "ApplicationUserId");
            DropColumn("dbo.Orders", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Feedbacks", "UserId");
            RenameIndex(table: "dbo.Orders", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Feedbacks", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
