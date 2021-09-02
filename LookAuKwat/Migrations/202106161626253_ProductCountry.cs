namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "ProductCountry", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "ProductCountry");
        }
    }
}
