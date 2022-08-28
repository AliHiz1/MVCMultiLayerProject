namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aboutlengthfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String(maxLength: 100));
        }
    }
}
