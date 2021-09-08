namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organization", "OrganizationName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Organization", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Organization", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Faq", "Question", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Faq", "Answered", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Partner", "PartnerName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "Email", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Partner", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Partner", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Partner", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "Email", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Partner", "PartnerName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Faq", "Answered", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Faq", "Question", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Organization", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Organization", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Organization", "OrganizationName", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
