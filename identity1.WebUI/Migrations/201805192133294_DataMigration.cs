namespace identity1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Status_StatusId", "dbo.Status");
            DropIndex("dbo.Orders", new[] { "Status_StatusId" });
            RenameColumn(table: "dbo.Orders", name: "Status_StatusId", newName: "StatusId");
            AddColumn("dbo.Feedbacks", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "ApplicationUser_Id");
            CreateIndex("dbo.Orders", "StatusId");
            CreateIndex("dbo.Orders", "ApplicationUser_Id");
            AddForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Orders", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            DropColumn("dbo.Orders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "StatusId" });
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Orders", "StatusId", c => c.Int());
            DropColumn("dbo.Orders", "ApplicationUser_Id");
            DropColumn("dbo.Feedbacks", "ApplicationUser_Id");
            RenameColumn(table: "dbo.Orders", name: "StatusId", newName: "Status_StatusId");
            CreateIndex("dbo.Orders", "Status_StatusId");
            AddForeignKey("dbo.Orders", "Status_StatusId", "dbo.Status", "StatusId");
        }
    }
}
