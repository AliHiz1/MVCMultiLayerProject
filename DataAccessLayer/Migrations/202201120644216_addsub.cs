namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subs",
                c => new
                    {
                        SubID = c.Int(nullable: false, identity: true),
                        SubMail = c.String(),
                    })
                .PrimaryKey(t => t.SubID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subs");
        }
    }
}
