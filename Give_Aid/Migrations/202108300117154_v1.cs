namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Partner");
            AlterColumn("dbo.Category", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Partner", "PartnerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Partner", "PartnerId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Partner");
            AlterColumn("dbo.Partner", "PartnerId", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Category", "Status", c => c.Boolean());
            AddPrimaryKey("dbo.Partner", "PartnerId");
        }
    }
}
