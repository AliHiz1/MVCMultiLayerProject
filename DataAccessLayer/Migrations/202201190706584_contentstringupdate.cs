namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contentstringupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "ContentValue", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "ContentValue", c => c.String(maxLength: 1000));
        }
    }
}
