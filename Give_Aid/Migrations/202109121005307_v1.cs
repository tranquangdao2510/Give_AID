namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutImg = c.String(unicode: false),
                        Title = c.String(nullable: false, unicode: false),
                        Content = c.String(nullable: false, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            AddColumn("dbo.Organization", "MetaTitle", c => c.String());
            AddColumn("dbo.Faq", "MetaTitle", c => c.String());
            AddColumn("dbo.ImageGallery", "Name", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.ImageGallery", "Image", c => c.String(maxLength: 500));
            AddColumn("dbo.ImageGallery", "TagId", c => c.Int());
            AddColumn("dbo.Partner", "MetaTitle", c => c.String());
            AddColumn("dbo.Slide", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Admin", "AdminName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Admin", "Email", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Admin", "PassWord", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Admin", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Admin", "Phone", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Fund", "FundName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Fund", "Description", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Fund", "TargetAmount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.Donate", "Content", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Customer", "PassWord", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Customer", "Phone", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Organization", "OrganizationName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Organization", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Organization", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Faq", "Question", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Faq", "Answered", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Partner", "PartnerName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "Email", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Partner", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Slide", "Description", c => c.String(nullable: false, maxLength: 500, unicode: false));
            AlterColumn("dbo.Slide", "Url", c => c.String(nullable: false, maxLength: 250, unicode: false));
            CreateIndex("dbo.ImageGallery", "TagId");
            AddForeignKey("dbo.ImageGallery", "TagId", "dbo.Tag", "TagId");
            DropColumn("dbo.Fund", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fund", "Title", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.ImageGallery", "TagId", "dbo.Tag");
            DropIndex("dbo.ImageGallery", new[] { "TagId" });
            AlterColumn("dbo.Slide", "Url", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Slide", "Description", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Partner", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Partner", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Partner", "Email", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Partner", "PartnerName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Faq", "Answered", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Faq", "Question", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Organization", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Organization", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Organization", "OrganizationName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Customer", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Customer", "PassWord", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Donate", "Content", c => c.String(maxLength: 250));
            AlterColumn("dbo.Fund", "TargetAmount", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.Fund", "Description", c => c.String(unicode: false));
            AlterColumn("dbo.Fund", "FundName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Category", "CategoryName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Admin", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Admin", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Admin", "PassWord", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Admin", "Email", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Admin", "AdminName", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Slide", "Title");
            DropColumn("dbo.Partner", "MetaTitle");
            DropColumn("dbo.ImageGallery", "TagId");
            DropColumn("dbo.ImageGallery", "Image");
            DropColumn("dbo.ImageGallery", "Name");
            DropColumn("dbo.Faq", "MetaTitle");
            DropColumn("dbo.Organization", "MetaTitle");
            DropTable("dbo.About");
        }
    }
}
