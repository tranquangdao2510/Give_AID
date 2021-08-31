namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donate", "Fund_FundId", "dbo.Fund");
            DropIndex("dbo.Donate", new[] { "Fund_FundId" });
            DropColumn("dbo.Donate", "FundId");
            RenameColumn(table: "dbo.Donate", name: "Fund_FundId", newName: "FundId");
            DropPrimaryKey("dbo.Fund");
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
            AlterColumn("dbo.Fund", "FundId", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Donate", "FundId", c => c.String(maxLength: 50, unicode: false));
            AddPrimaryKey("dbo.Fund", "FundId");
            CreateIndex("dbo.Donate", "FundId");
            AddForeignKey("dbo.Donate", "FundId", "dbo.Fund", "FundId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donate", "FundId", "dbo.Fund");
            DropIndex("dbo.Donate", new[] { "FundId" });
            DropPrimaryKey("dbo.Fund");
            AlterColumn("dbo.Donate", "FundId", c => c.Int());
            AlterColumn("dbo.Fund", "FundId", c => c.Int(nullable: false, identity: true));
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
            AddPrimaryKey("dbo.Fund", "FundId");
            RenameColumn(table: "dbo.Donate", name: "FundId", newName: "Fund_FundId");
            AddColumn("dbo.Donate", "FundId", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("dbo.Donate", "Fund_FundId");
            AddForeignKey("dbo.Donate", "Fund_FundId", "dbo.Fund", "FundId");
        }
    }
}
