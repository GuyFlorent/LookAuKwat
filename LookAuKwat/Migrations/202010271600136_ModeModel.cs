namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "RubriqueMode", c => c.String());
            AddColumn("dbo.ProductModels", "TypeMode", c => c.String());
            AddColumn("dbo.ProductModels", "BrandMode", c => c.String());
            AddColumn("dbo.ProductModels", "UniversMode", c => c.String());
            AddColumn("dbo.ProductModels", "SizeMode", c => c.String());
            AddColumn("dbo.ProductModels", "ColorMode", c => c.String());
            AddColumn("dbo.ProductModels", "StateMode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "StateMode");
            DropColumn("dbo.ProductModels", "ColorMode");
            DropColumn("dbo.ProductModels", "SizeMode");
            DropColumn("dbo.ProductModels", "UniversMode");
            DropColumn("dbo.ProductModels", "BrandMode");
            DropColumn("dbo.ProductModels", "TypeMode");
            DropColumn("dbo.ProductModels", "RubriqueMode");
        }
    }
}
