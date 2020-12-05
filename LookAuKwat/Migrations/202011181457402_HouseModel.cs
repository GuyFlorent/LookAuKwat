namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HouseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "RubriqueHouse", c => c.String());
            AddColumn("dbo.ProductModels", "TypeHouse", c => c.String());
            AddColumn("dbo.ProductModels", "FabricMaterialeHouse", c => c.String());
            AddColumn("dbo.ProductModels", "ColorHouse", c => c.String());
            AddColumn("dbo.ProductModels", "StateHouse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "StateHouse");
            DropColumn("dbo.ProductModels", "ColorHouse");
            DropColumn("dbo.ProductModels", "FabricMaterialeHouse");
            DropColumn("dbo.ProductModels", "TypeHouse");
            DropColumn("dbo.ProductModels", "RubriqueHouse");
        }
    }
}
