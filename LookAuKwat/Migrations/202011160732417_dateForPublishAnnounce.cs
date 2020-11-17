namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateForPublishAnnounce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Date_First_Publish", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Date_First_Publish");
        }
    }
}
