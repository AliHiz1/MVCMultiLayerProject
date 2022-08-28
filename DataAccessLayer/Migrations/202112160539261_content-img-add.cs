namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contentimgadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentImage");
        }
    }
}
