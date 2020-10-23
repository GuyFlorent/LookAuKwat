namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVehiculeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "RubriqueVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "BrandVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "ModelVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "TypeVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "PetrolVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "FirstYearVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "YearVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "MileageVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "NumberOfDoorVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "ColorVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "GearBoxVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "ModelAccessoryAutoVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "ModelAccessoryBikeVehicule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "ModelAccessoryBikeVehicule");
            DropColumn("dbo.ProductModels", "ModelAccessoryAutoVehicule");
            DropColumn("dbo.ProductModels", "GearBoxVehicule");
            DropColumn("dbo.ProductModels", "ColorVehicule");
            DropColumn("dbo.ProductModels", "NumberOfDoorVehicule");
            DropColumn("dbo.ProductModels", "MileageVehicule");
            DropColumn("dbo.ProductModels", "YearVehicule");
            DropColumn("dbo.ProductModels", "FirstYearVehicule");
            DropColumn("dbo.ProductModels", "PetrolVehicule");
            DropColumn("dbo.ProductModels", "TypeVehicule");
            DropColumn("dbo.ProductModels", "ModelVehicule");
            DropColumn("dbo.ProductModels", "BrandVehicule");
            DropColumn("dbo.ProductModels", "RubriqueVehicule");
        }
    }
}
