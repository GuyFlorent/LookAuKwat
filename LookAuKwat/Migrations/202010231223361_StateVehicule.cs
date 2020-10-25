namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StateVehicule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "StateVehicule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "StateVehicule");
        }
    }
}
