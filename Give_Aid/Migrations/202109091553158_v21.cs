namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "PassWord", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Customer", "Phone", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Customer", "PassWord", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
