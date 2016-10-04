namespace Wardrobe00.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedtypeidfrommodels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bottoms", "typeID");
            DropColumn("dbo.Accessories", "typeID");
            DropColumn("dbo.Shoes", "typeID");
            DropColumn("dbo.Tops", "typeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tops", "typeID", c => c.Int(nullable: false));
            AddColumn("dbo.Shoes", "typeID", c => c.Int(nullable: false));
            AddColumn("dbo.Accessories", "typeID", c => c.Int(nullable: false));
            AddColumn("dbo.Bottoms", "typeID", c => c.Int(nullable: false));
        }
    }
}
