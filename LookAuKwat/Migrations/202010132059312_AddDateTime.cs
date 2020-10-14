namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductModels", "DateAdd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductModels", "DateAdd", c => c.String());
        }
    }
}
