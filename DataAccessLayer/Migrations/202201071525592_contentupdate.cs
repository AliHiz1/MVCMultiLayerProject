namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contentupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "CommentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "CommentID");
        }
    }
}
