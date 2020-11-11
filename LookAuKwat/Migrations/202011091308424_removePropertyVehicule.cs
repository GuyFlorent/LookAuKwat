namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePropertyVehicule : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductModels", "ModelAccessoryAutoVehicule");
            DropColumn("dbo.ProductModels", "ModelAccessoryBikeVehicule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductModels", "ModelAccessoryBikeVehicule", c => c.String());
            AddColumn("dbo.ProductModels", "ModelAccessoryAutoVehicule", c => c.String());
        }
    }
}
