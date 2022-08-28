namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writerroleadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterRole");
        }
    }
}
