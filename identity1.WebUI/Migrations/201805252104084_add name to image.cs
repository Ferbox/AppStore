namespace identity1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnametoimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Name");
        }
    }
}