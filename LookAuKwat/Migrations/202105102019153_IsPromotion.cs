namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPromotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "IsPromotion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "IsPromotion");
        }
    }
}
