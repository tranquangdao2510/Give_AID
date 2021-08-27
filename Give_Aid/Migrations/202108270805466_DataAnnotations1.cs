namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comtact", "Phone", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Comtact", "Message", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Comtact", "FirstName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "LastName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "Email", c => c.String(nullable: false, maxLength: 250, unicode: false));
            DropColumn("dbo.Comtact", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comtact", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Comtact", "Email", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Comtact", "LastName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "FirstName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "Message", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Comtact", "Phone", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
