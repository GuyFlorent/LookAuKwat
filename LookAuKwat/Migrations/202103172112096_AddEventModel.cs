namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "Stock_Initial", c => c.Int(nullable: false));
            AddColumn("dbo.ProductModels", "RubriqueEvent", c => c.String());
            AddColumn("dbo.ProductModels", "TypeEvent", c => c.String());
            AddColumn("dbo.ProductModels", "Sport_Game", c => c.String());
            AddColumn("dbo.ProductModels", "Artist_Name", c => c.String());
            AddColumn("dbo.ProductModels", "DateEvent", c => c.DateTime());
            AddColumn("dbo.ProductModels", "Hour", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "Hour");
            DropColumn("dbo.ProductModels", "DateEvent");
            DropColumn("dbo.ProductModels", "Artist_Name");
            DropColumn("dbo.ProductModels", "Sport_Game");
            DropColumn("dbo.ProductModels", "TypeEvent");
            DropColumn("dbo.ProductModels", "RubriqueEvent");
            DropColumn("dbo.ProductModels", "Stock_Initial");
        }
    }
}
