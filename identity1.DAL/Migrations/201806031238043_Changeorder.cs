namespace identity1.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Count", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Quantity");
        }
    }
}
