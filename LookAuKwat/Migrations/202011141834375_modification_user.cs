namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modification_user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Parrain_Id", "dbo.ParrainModels");
            DropIndex("dbo.AspNetUsers", new[] { "Parrain_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AspNetUsers", "Parrain_Id");
            AddForeignKey("dbo.AspNetUsers", "Parrain_Id", "dbo.ParrainModels", "Id");
        }
    }
}
