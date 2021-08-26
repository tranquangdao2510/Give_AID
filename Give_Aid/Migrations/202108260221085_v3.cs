namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fund", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Donate", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customer", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Payment", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Organization", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Faq", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Partner", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Slide", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Volunteer", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteer", "Status", c => c.Boolean());
            AlterColumn("dbo.Slide", "Status", c => c.Boolean());
            AlterColumn("dbo.Partner", "Status", c => c.Boolean());
            AlterColumn("dbo.Faq", "Status", c => c.Boolean());
            AlterColumn("dbo.Organization", "Status", c => c.Boolean());
            AlterColumn("dbo.Payment", "Status", c => c.Boolean());
            AlterColumn("dbo.Customer", "Status", c => c.Boolean());
            AlterColumn("dbo.Donate", "Status", c => c.Boolean());
            AlterColumn("dbo.Fund", "Status", c => c.Boolean());
        }
    }
}
