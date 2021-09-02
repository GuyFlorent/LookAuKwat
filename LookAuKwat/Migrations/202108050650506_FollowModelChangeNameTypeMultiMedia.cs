namespace LookAuKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowModelChangeNameTypeMultiMedia : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductModels", name: "Type1", newName: "TypeMultimedia");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.ProductModels", name: "TypeMultimedia", newName: "Type1");
        }
    }
}
