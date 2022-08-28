namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentcontentchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ContentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ContentID");
            AddForeignKey("dbo.Comments", "ContentID", "dbo.Contents", "ContentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ContentID", "dbo.Contents");
            DropIndex("dbo.Comments", new[] { "ContentID" });
            DropColumn("dbo.Comments", "ContentID");
        }
    }
}
