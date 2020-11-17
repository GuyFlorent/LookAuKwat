namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParrainModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date_createParrain = c.DateTime(nullable: false),
                        ParrainEmail = c.String(),
                        ParrainFirstName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Date_Create_Account", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Parrain_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Parrain_Id");
            AddForeignKey("dbo.AspNetUsers", "Parrain_Id", "dbo.ParrainModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Parrain_Id", "dbo.ParrainModels");
            DropIndex("dbo.AspNetUsers", new[] { "Parrain_Id" });
            DropColumn("dbo.AspNetUsers", "Parrain_Id");
            DropColumn("dbo.AspNetUsers", "Date_Create_Account");
            DropTable("dbo.ParrainModels");
        }
    }
}
