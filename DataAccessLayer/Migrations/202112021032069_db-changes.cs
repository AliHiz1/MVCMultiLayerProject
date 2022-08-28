namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 50));
        }
    }
}
