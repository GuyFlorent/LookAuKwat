namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FollowModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Follower_Email = c.String(),
                        Follower_Id = c.String(),
                        IsNotify_For_new_Followar = c.Boolean(nullable: false),
                        User_New_Announce_AlreadyNotifyTo_follower = c.Boolean(nullable: false),
                        followedDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FollowModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FollowModels", new[] { "User_Id" });
            DropTable("dbo.FollowModels");
        }
    }
}
