namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "ConnectionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ConnectionId", c => c.String());
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
