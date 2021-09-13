namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Partner", "Email", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "Phone", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Partner", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Partner", "Email", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
    }
}
