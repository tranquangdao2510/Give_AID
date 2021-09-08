namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faq", "Question", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Faq", "Answered", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faq", "Answered", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Faq", "Question", c => c.String(nullable: false, unicode: false, storeType: "text"));
        }
    }
}
