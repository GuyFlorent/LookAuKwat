namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsByLookaukwat = c.Boolean(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Product_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductModels", t => t.Product_id)
                .Index(t => t.Product_id);
            
            AddColumn("dbo.ProductModels", "VideoUrl", c => c.String());
            AddColumn("dbo.PurchaseModels", "StartDate", c => c.DateTime());
            AddColumn("dbo.PurchaseModels", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "Product_id", "dbo.ProductModels");
            DropIndex("dbo.BookingModels", new[] { "Product_id" });
            DropColumn("dbo.PurchaseModels", "EndDate");
            DropColumn("dbo.PurchaseModels", "StartDate");
            DropColumn("dbo.ProductModels", "VideoUrl");
            DropTable("dbo.BookingModels");
        }
    }
}
