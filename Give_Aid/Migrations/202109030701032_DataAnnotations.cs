namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Volunteer", "CreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteer", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
