namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writerupdate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "WriterRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterRole", c => c.String());
        }
    }
}
