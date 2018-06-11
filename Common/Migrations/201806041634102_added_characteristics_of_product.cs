namespace identity1.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_characteristics_of_product : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.CharacteristicsId)
                .ForeignKey("dbo.Colors", t => t.ColorId)
                .ForeignKey("dbo.Displays", t => t.DisplayId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.SizeBodies", t => t.SizeBodyId)
                .Index(t => t.MemberId)
                .Index(t => t.ColorId)
                .Index(t => t.DisplayId)
                .Index(t => t.SizeBodyId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.Displays",
                c => new
                    {
                        DisplayId = c.Int(nullable: false, identity: true),
                        Size = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DisplayId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        MemoryGB = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.SizeBodies",
                c => new
                    {
                        SizeBodyId = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SizeBodyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characteristics", "SizeBodyId", "dbo.SizeBodies");
            DropForeignKey("dbo.Characteristics", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Characteristics", "DisplayId", "dbo.Displays");
            DropForeignKey("dbo.Characteristics", "ColorId", "dbo.Colors");
            DropIndex("dbo.Characteristics", new[] { "SizeBodyId" });
            DropIndex("dbo.Characteristics", new[] { "DisplayId" });
            DropIndex("dbo.Characteristics", new[] { "ColorId" });
            DropIndex("dbo.Characteristics", new[] { "MemberId" });
            DropTable("dbo.SizeBodies");
            DropTable("dbo.Members");
            DropTable("dbo.Displays");
            DropTable("dbo.Colors");
            DropTable("dbo.Characteristics");
        }
    }
}
