namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dao : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Partner");
            AddColumn("dbo.Blog", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Tag", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Tag", "DisplayOrder", c => c.Int());
            AddColumn("dbo.Category", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Fund", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Fund", "DisplayOrder", c => c.Int());
            AddColumn("dbo.Customer", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Comtact", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.ImageGallery", "MetaTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Volunteer", "MetaTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Category", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Comtact", "Phone", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Comtact", "Message", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Comtact", "FirstName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "LastName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "Email", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "PartnerId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Volunteer", "VolunteersName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Volunteer", "Email", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Volunteer", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Volunteer", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Volunteer", "BirthDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Volunteer", "CreateDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Partner", "PartnerId");
            DropColumn("dbo.Comtact", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comtact", "Address", c => c.String(maxLength: 250, unicode: false));
            DropPrimaryKey("dbo.Partner");
            AlterColumn("dbo.Volunteer", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Volunteer", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Volunteer", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Volunteer", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Volunteer", "Email", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Volunteer", "VolunteersName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "PartnerId", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "Email", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Comtact", "LastName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "FirstName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Comtact", "Message", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Comtact", "Phone", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Category", "Status", c => c.Boolean());
            DropColumn("dbo.Volunteer", "MetaTitle");
            DropColumn("dbo.ImageGallery", "MetaTitle");
            DropColumn("dbo.Comtact", "MetaTitle");
            DropColumn("dbo.Customer", "MetaTitle");
            DropColumn("dbo.Fund", "DisplayOrder");
            DropColumn("dbo.Fund", "MetaTitle");
            DropColumn("dbo.Category", "MetaTitle");
            DropColumn("dbo.Tag", "DisplayOrder");
            DropColumn("dbo.Tag", "MetaTitle");
            DropColumn("dbo.Blog", "MetaTitle");
            AddPrimaryKey("dbo.Partner", "PartnerId");
        }
    }
}
