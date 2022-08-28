namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcommenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentUserName = c.String(),
                        CommentUserMail = c.String(),
                        CommentMessage = c.String(),
                        CommentStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
