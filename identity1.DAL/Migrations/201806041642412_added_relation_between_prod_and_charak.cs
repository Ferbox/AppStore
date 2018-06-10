namespace identity1.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_relation_between_prod_and_charak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CharacteristicsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CharacteristicsId");
            AddForeignKey("dbo.Products", "CharacteristicsId", "dbo.Characteristics", "CharacteristicsId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CharacteristicsId", "dbo.Characteristics");
            DropIndex("dbo.Products", new[] { "CharacteristicsId" });
            DropColumn("dbo.Products", "CharacteristicsId");
        }
    }
}
