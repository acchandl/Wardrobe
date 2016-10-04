namespace Wardrobe00.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelstookouttypeid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bottoms", "typeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bottoms", "typeID", c => c.String());
        }
    }
}
