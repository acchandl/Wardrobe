namespace Wardrobe00.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecascadedelete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bottoms",
                c => new
                    {
                        bottomID = c.Int(nullable: false, identity: true),
                        typeID = c.Int(nullable: false),
                        bottomName = c.String(),
                        photo = c.String(),
                        seasonID = c.Int(nullable: false),
                        occasionID = c.Int(nullable: false),
                        colorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bottomID)
                .ForeignKey("dbo.Colors", t => t.colorID)
                .ForeignKey("dbo.Occasions", t => t.occasionID)
                .ForeignKey("dbo.Seasons", t => t.seasonID)
                .Index(t => t.seasonID)
                .Index(t => t.occasionID)
                .Index(t => t.colorID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        colorID = c.Int(nullable: false, identity: true),
                        colorName = c.String(),
                    })
                .PrimaryKey(t => t.colorID);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        occasionID = c.Int(nullable: false, identity: true),
                        occasionName = c.String(),
                    })
                .PrimaryKey(t => t.occasionID);
            
            CreateTable(
                "dbo.Outfits",
                c => new
                    {
                        outfitID = c.Int(nullable: false, identity: true),
                        topID = c.Int(nullable: false),
                        bottomID = c.Int(nullable: false),
                        shoeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.outfitID)
                .ForeignKey("dbo.Bottoms", t => t.bottomID)
                .ForeignKey("dbo.Shoes", t => t.shoeID)
                .ForeignKey("dbo.Tops", t => t.topID)
                .Index(t => t.topID)
                .Index(t => t.bottomID)
                .Index(t => t.shoeID);
            
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        accessoryID = c.Int(nullable: false, identity: true),
                        typeID = c.Int(nullable: false),
                        accessoryName = c.String(),
                        photo = c.String(),
                        Outfit_outfitID = c.Int(),
                    })
                .PrimaryKey(t => t.accessoryID)
                .ForeignKey("dbo.Outfits", t => t.Outfit_outfitID)
                .Index(t => t.Outfit_outfitID);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        shoeID = c.Int(nullable: false, identity: true),
                        typeID = c.Int(nullable: false),
                        shoeName = c.String(),
                        photo = c.String(),
                        seasonID = c.Int(nullable: false),
                        occasionID = c.Int(nullable: false),
                        colorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.shoeID)
                .ForeignKey("dbo.Colors", t => t.colorID)
                .ForeignKey("dbo.Occasions", t => t.occasionID)
                .ForeignKey("dbo.Seasons", t => t.seasonID)
                .Index(t => t.seasonID)
                .Index(t => t.occasionID)
                .Index(t => t.colorID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        seasonID = c.Int(nullable: false, identity: true),
                        seasonName = c.String(),
                    })
                .PrimaryKey(t => t.seasonID);
            
            CreateTable(
                "dbo.Tops",
                c => new
                    {
                        topID = c.Int(nullable: false, identity: true),
                        typeID = c.Int(nullable: false),
                        topName = c.String(),
                        photo = c.String(),
                        seasonID = c.Int(nullable: false),
                        occasionID = c.Int(nullable: false),
                        colorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.topID)
                .ForeignKey("dbo.Colors", t => t.colorID)
                .ForeignKey("dbo.Occasions", t => t.occasionID)
                .ForeignKey("dbo.Seasons", t => t.seasonID)
                .Index(t => t.seasonID)
                .Index(t => t.occasionID)
                .Index(t => t.colorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bottoms", "seasonID", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "seasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "topID", "dbo.Tops");
            DropForeignKey("dbo.Tops", "occasionID", "dbo.Occasions");
            DropForeignKey("dbo.Tops", "colorID", "dbo.Colors");
            DropForeignKey("dbo.Shoes", "seasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "shoeID", "dbo.Shoes");
            DropForeignKey("dbo.Shoes", "occasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "colorID", "dbo.Colors");
            DropForeignKey("dbo.Outfits", "bottomID", "dbo.Bottoms");
            DropForeignKey("dbo.Accessories", "Outfit_outfitID", "dbo.Outfits");
            DropForeignKey("dbo.Bottoms", "occasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "colorID", "dbo.Colors");
            DropIndex("dbo.Tops", new[] { "colorID" });
            DropIndex("dbo.Tops", new[] { "occasionID" });
            DropIndex("dbo.Tops", new[] { "seasonID" });
            DropIndex("dbo.Shoes", new[] { "colorID" });
            DropIndex("dbo.Shoes", new[] { "occasionID" });
            DropIndex("dbo.Shoes", new[] { "seasonID" });
            DropIndex("dbo.Accessories", new[] { "Outfit_outfitID" });
            DropIndex("dbo.Outfits", new[] { "shoeID" });
            DropIndex("dbo.Outfits", new[] { "bottomID" });
            DropIndex("dbo.Outfits", new[] { "topID" });
            DropIndex("dbo.Bottoms", new[] { "colorID" });
            DropIndex("dbo.Bottoms", new[] { "occasionID" });
            DropIndex("dbo.Bottoms", new[] { "seasonID" });
            DropTable("dbo.Tops");
            DropTable("dbo.Seasons");
            DropTable("dbo.Shoes");
            DropTable("dbo.Accessories");
            DropTable("dbo.Outfits");
            DropTable("dbo.Occasions");
            DropTable("dbo.Colors");
            DropTable("dbo.Bottoms");
        }
    }
}
