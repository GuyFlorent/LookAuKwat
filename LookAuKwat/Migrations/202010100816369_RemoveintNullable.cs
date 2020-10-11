namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveintNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductModels", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductModels", "Price", c => c.Int());
        }
    }
}
