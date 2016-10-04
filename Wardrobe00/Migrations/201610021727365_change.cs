namespace Wardrobe00.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessories", "Outfit_outfitID", "dbo.Outfits");
            DropIndex("dbo.Accessories", new[] { "Outfit_outfitID" });
            CreateTable(
                "dbo.AccessoryOutfits",
                c => new
                    {
                        Accessory_accessoryID = c.Int(nullable: false),
                        Outfit_outfitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Accessory_accessoryID, t.Outfit_outfitID })
                .ForeignKey("dbo.Accessories", t => t.Accessory_accessoryID, cascadeDelete: true)
                .ForeignKey("dbo.Outfits", t => t.Outfit_outfitID, cascadeDelete: true)
                .Index(t => t.Accessory_accessoryID)
                .Index(t => t.Outfit_outfitID);
            
            AddColumn("dbo.Bottoms", "typeID", c => c.String());
            AddColumn("dbo.Accessories", "colorID", c => c.Int(nullable: false));
            AddColumn("dbo.Accessories", "seasonID", c => c.Int(nullable: false));
            AddColumn("dbo.Accessories", "occasionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accessories", "colorID");
            CreateIndex("dbo.Accessories", "seasonID");
            CreateIndex("dbo.Accessories", "occasionID");
            AddForeignKey("dbo.Accessories", "colorID", "dbo.Colors", "colorID");
            AddForeignKey("dbo.Accessories", "occasionID", "dbo.Occasions", "occasionID");
            AddForeignKey("dbo.Accessories", "seasonID", "dbo.Seasons", "seasonID");
            DropColumn("dbo.Accessories", "Outfit_outfitID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accessories", "Outfit_outfitID", c => c.Int());
            DropForeignKey("dbo.Accessories", "seasonID", "dbo.Seasons");
            DropForeignKey("dbo.AccessoryOutfits", "Outfit_outfitID", "dbo.Outfits");
            DropForeignKey("dbo.AccessoryOutfits", "Accessory_accessoryID", "dbo.Accessories");
            DropForeignKey("dbo.Accessories", "occasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "colorID", "dbo.Colors");
            DropIndex("dbo.AccessoryOutfits", new[] { "Outfit_outfitID" });
            DropIndex("dbo.AccessoryOutfits", new[] { "Accessory_accessoryID" });
            DropIndex("dbo.Accessories", new[] { "occasionID" });
            DropIndex("dbo.Accessories", new[] { "seasonID" });
            DropIndex("dbo.Accessories", new[] { "colorID" });
            DropColumn("dbo.Accessories", "occasionID");
            DropColumn("dbo.Accessories", "seasonID");
            DropColumn("dbo.Accessories", "colorID");
            DropColumn("dbo.Bottoms", "typeID");
            DropTable("dbo.AccessoryOutfits");
            CreateIndex("dbo.Accessories", "Outfit_outfitID");
            AddForeignKey("dbo.Accessories", "Outfit_outfitID", "dbo.Outfits", "outfitID");
        }
    }
}
