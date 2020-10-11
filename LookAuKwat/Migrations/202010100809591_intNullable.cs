namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductModels", "Price", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductModels", "Price", c => c.Int(nullable: false));
        }
    }
}
