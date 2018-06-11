namespace identity1.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveryAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DeliveryAddress");
        }
    }
}
