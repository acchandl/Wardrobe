namespace Wardrobe00.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaccessorycontroller : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccessoryOutfits", newName: "OutfitAccessories");
            DropPrimaryKey("dbo.OutfitAccessories");
            AddPrimaryKey("dbo.OutfitAccessories", new[] { "Outfit_outfitID", "Accessory_accessoryID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OutfitAccessories");
            AddPrimaryKey("dbo.OutfitAccessories", new[] { "Accessory_accessoryID", "Outfit_outfitID" });
            RenameTable(name: "dbo.OutfitAccessories", newName: "AccessoryOutfits");
        }
    }
}
