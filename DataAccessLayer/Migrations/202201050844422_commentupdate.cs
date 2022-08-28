namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ContentID", "dbo.Contents");
            DropIndex("dbo.Comments", new[] { "ContentID" });
            RenameColumn(table: "dbo.Comments", name: "ContentID", newName: "Content_ContentID");
            AddColumn("dbo.Comments", "ContenttID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Content_ContentID", c => c.Int());
            CreateIndex("dbo.Comments", "Content_ContentID");
            AddForeignKey("dbo.Comments", "Content_ContentID", "dbo.Contents", "ContentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Content_ContentID", "dbo.Contents");
            DropIndex("dbo.Comments", new[] { "Content_ContentID" });
            AlterColumn("dbo.Comments", "Content_ContentID", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "ContenttID");
            RenameColumn(table: "dbo.Comments", name: "Content_ContentID", newName: "ContentID");
            CreateIndex("dbo.Comments", "ContentID");
            AddForeignKey("dbo.Comments", "ContentID", "dbo.Contents", "ContentID", cascadeDelete: true);
        }
    }
}
