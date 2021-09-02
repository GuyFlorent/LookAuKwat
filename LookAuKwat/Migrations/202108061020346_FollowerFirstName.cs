namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowerFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FollowModels", "Follower_FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FollowModels", "Follower_FirstName");
        }
    }
}
