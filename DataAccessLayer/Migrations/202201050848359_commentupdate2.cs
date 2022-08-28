namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentupdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Content_ContentID", "dbo.Contents");
            DropIndex("dbo.Comments", new[] { "Content_ContentID" });
            RenameColumn(table: "dbo.Comments", name: "Content_ContentID", newName: "ContentID");
            AlterColumn("dbo.Comments", "ContentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ContentID");
            AddForeignKey("dbo.Comments", "ContentID", "dbo.Contents", "ContentID", cascadeDelete: true);
            DropColumn("dbo.Comments", "ContenttID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ContenttID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "ContentID", "dbo.Contents");
            DropIndex("dbo.Comments", new[] { "ContentID" });
            AlterColumn("dbo.Comments", "ContentID", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "ContentID", newName: "Content_ContentID");
            CreateIndex("dbo.Comments", "Content_ContentID");
            AddForeignKey("dbo.Comments", "Content_ContentID", "dbo.Contents", "ContentID");
        }
    }
}
