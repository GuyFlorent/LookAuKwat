namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommandModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Int(nullable: false),
                        DeliveredPrice = c.Int(nullable: false),
                        Distance = c.String(),
                        PayementMethod = c.String(),
                        CommandId = c.Int(nullable: false),
                        CommandDate = c.DateTime(),
                        DeliveredDate = c.DateTime(),
                        IsHomeDelivered = c.Boolean(nullable: false),
                        IsDelivered = c.Boolean(nullable: false),
                        IsDeleteByUser = c.Boolean(nullable: false),
                        DeliveredAdress_Id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveredAdressModels", t => t.DeliveredAdress_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.DeliveredAdress_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.DeliveredAdressModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Town = c.String(),
                        Street = c.String(),
                        Number = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantities = c.Int(nullable: false),
                        Command_Id = c.Int(),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommandModels", t => t.Command_Id)
                .ForeignKey("dbo.ProductModels", t => t.product_id)
                .Index(t => t.Command_Id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.TrackingCommandModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Town = c.String(),
                        Street = c.String(),
                        Road = c.String(),
                        Date = c.DateTime(nullable: false),
                        Lat = c.String(),
                        Lon = c.String(),
                        Command_Id = c.Int(),
                        UserAgent_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommandModels", t => t.Command_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAgent_Id)
                .Index(t => t.Command_Id)
                .Index(t => t.UserAgent_Id);
            
            AddColumn("dbo.ProductModels", "CallNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductModels", "MessageNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductModels", "Provider_Id", c => c.String());
            AddColumn("dbo.ProductModels", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductModels", "IsLookaukwat", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductModels", "IsParticulier", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductModels", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackingCommandModels", "UserAgent_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrackingCommandModels", "Command_Id", "dbo.CommandModels");
            DropForeignKey("dbo.CommandModels", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseModels", "product_id", "dbo.ProductModels");
            DropForeignKey("dbo.PurchaseModels", "Command_Id", "dbo.CommandModels");
            DropForeignKey("dbo.CommandModels", "DeliveredAdress_Id", "dbo.DeliveredAdressModels");
            DropIndex("dbo.TrackingCommandModels", new[] { "UserAgent_Id" });
            DropIndex("dbo.TrackingCommandModels", new[] { "Command_Id" });
            DropIndex("dbo.PurchaseModels", new[] { "product_id" });
            DropIndex("dbo.PurchaseModels", new[] { "Command_Id" });
            DropIndex("dbo.CommandModels", new[] { "user_Id" });
            DropIndex("dbo.CommandModels", new[] { "DeliveredAdress_Id" });
            DropColumn("dbo.ProductModels", "Stock");
            DropColumn("dbo.ProductModels", "IsParticulier");
            DropColumn("dbo.ProductModels", "IsLookaukwat");
            DropColumn("dbo.ProductModels", "IsActive");
            DropColumn("dbo.ProductModels", "Provider_Id");
            DropColumn("dbo.ProductModels", "MessageNumber");
            DropColumn("dbo.ProductModels", "CallNumber");
            DropTable("dbo.TrackingCommandModels");
            DropTable("dbo.PurchaseModels");
            DropTable("dbo.DeliveredAdressModels");
            DropTable("dbo.CommandModels");
        }
    }
}
