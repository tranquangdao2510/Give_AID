namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tqdao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.About", "MetaTitle", c => c.String());
            AddColumn("dbo.Organization", "MetaTitle", c => c.String());
            AddColumn("dbo.Faq", "MetaTitle", c => c.String());
            AddColumn("dbo.Partner", "MetaTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partner", "MetaTitle");
            DropColumn("dbo.Faq", "MetaTitle");
            DropColumn("dbo.Organization", "MetaTitle");
            DropColumn("dbo.About", "MetaTitle");
        }
    }
}
