namespace identity1.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CharacteristicsId", "dbo.Characteristics");
            DropForeignKey("dbo.Characteristics", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Characteristics", "DisplayId", "dbo.Displays");
            DropForeignKey("dbo.Characteristics", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Characteristics", "SizeBodyId", "dbo.SizeBodies");
            DropIndex("dbo.Characteristics", new[] { "MemberId" });
            DropIndex("dbo.Characteristics", new[] { "ColorId" });
            DropIndex("dbo.Characteristics", new[] { "DisplayId" });
            DropIndex("dbo.Characteristics", new[] { "SizeBodyId" });
            DropIndex("dbo.Products", new[] { "CharacteristicsId" });
            AddColumn("dbo.Products", "MemberId", c => c.Int());
            AddColumn("dbo.Products", "ColorId", c => c.Int());
            AddColumn("dbo.Products", "DisplayId", c => c.Int());
            AddColumn("dbo.Products", "SizeBodyId", c => c.Int());
            AddColumn("dbo.Products", "Cellular", c => c.Boolean());
            AddColumn("dbo.Products", "TouchBar", c => c.Boolean());
            CreateIndex("dbo.Products", "MemberId");
            CreateIndex("dbo.Products", "ColorId");
            CreateIndex("dbo.Products", "DisplayId");
            CreateIndex("dbo.Products", "SizeBodyId");
            AddForeignKey("dbo.Products", "ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Products", "DisplayId", "dbo.Displays", "DisplayId");
            AddForeignKey("dbo.Products", "MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Products", "SizeBodyId", "dbo.SizeBodies", "SizeBodyId");
            DropColumn("dbo.Products", "CharacteristicsId");
            DropTable("dbo.Characteristics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Characteristics",
                c => new
                    {
                        CharacteristicsId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        ColorId = c.Int(),
                        DisplayId = c.Int(),
                        SizeBodyId = c.Int(),
                        Cellular = c.Boolean(),
                        TouchBar = c.Boolean(),
                    })
                .PrimaryKey(t => t.CharacteristicsId);
            
            AddColumn("dbo.Products", "CharacteristicsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "SizeBodyId", "dbo.SizeBodies");
            DropForeignKey("dbo.Products", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Products", "DisplayId", "dbo.Displays");
            DropForeignKey("dbo.Products", "ColorId", "dbo.Colors");
            DropIndex("dbo.Products", new[] { "SizeBodyId" });
            DropIndex("dbo.Products", new[] { "DisplayId" });
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.Products", new[] { "MemberId" });
            DropColumn("dbo.Products", "TouchBar");
            DropColumn("dbo.Products", "Cellular");
            DropColumn("dbo.Products", "SizeBodyId");
            DropColumn("dbo.Products", "DisplayId");
            DropColumn("dbo.Products", "ColorId");
            DropColumn("dbo.Products", "MemberId");
            CreateIndex("dbo.Products", "CharacteristicsId");
            CreateIndex("dbo.Characteristics", "SizeBodyId");
            CreateIndex("dbo.Characteristics", "DisplayId");
            CreateIndex("dbo.Characteristics", "ColorId");
            CreateIndex("dbo.Characteristics", "MemberId");
            AddForeignKey("dbo.Characteristics", "SizeBodyId", "dbo.SizeBodies", "SizeBodyId");
            AddForeignKey("dbo.Characteristics", "MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Characteristics", "DisplayId", "dbo.Displays", "DisplayId");
            AddForeignKey("dbo.Characteristics", "ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Products", "CharacteristicsId", "dbo.Characteristics", "CharacteristicsId", cascadeDelete: true);
        }
    }
}
