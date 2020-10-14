namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewClassMultimedia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "Type1", c => c.String());
            AddColumn("dbo.ProductModels", "Brand", c => c.String());
            AddColumn("dbo.ProductModels", "Model", c => c.String());
            AddColumn("dbo.ProductModels", "Capacity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "Capacity");
            DropColumn("dbo.ProductModels", "Model");
            DropColumn("dbo.ProductModels", "Brand");
            DropColumn("dbo.ProductModels", "Type1");
        }
    }
}
