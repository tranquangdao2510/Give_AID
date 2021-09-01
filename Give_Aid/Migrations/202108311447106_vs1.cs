namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donate", "NameCrad", c => c.String(maxLength: 200));
            AddColumn("dbo.Donate", "CradNumber", c => c.String(maxLength: 200));
            AddColumn("dbo.Comtact", "Address", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AddColumn("dbo.Comtact", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Comtact", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Blog", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tag", "CreateDate", c => c.DateTime());
            DropColumn("dbo.Comtact", "Message");
            DropColumn("dbo.Comtact", "FirstName");
            DropColumn("dbo.Comtact", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comtact", "LastName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Comtact", "FirstName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Comtact", "Message", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Tag", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blog", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Comtact", "Status");
            DropColumn("dbo.Comtact", "UpdateDate");
            DropColumn("dbo.Comtact", "Address");
            DropColumn("dbo.Donate", "CradNumber");
            DropColumn("dbo.Donate", "NameCrad");
        }
    }
}
