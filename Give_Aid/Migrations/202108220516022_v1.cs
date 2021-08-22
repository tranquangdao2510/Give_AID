namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        PassWord = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        BirthDay = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 250, unicode: false),
                        BlogImage = c.String(maxLength: 500, unicode: false),
                        TagId = c.Int(),
                        Content = c.String(unicode: false, storeType: "text"),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Tag", t => t.TagId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Fund",
                c => new
                    {
                        FundId = c.String(nullable: false, maxLength: 50, unicode: false),
                        FundName = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 300, unicode: false),
                        Content = c.String(unicode: false),
                        FundImg = c.String(maxLength: 500, unicode: false),
                        TargetAmount = c.Decimal(precision: 18, scale: 0),
                        CurentAmount = c.Decimal(precision: 18, scale: 0),
                        CategoryId = c.Int(),
                        OrganizationId = c.Int(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.FundId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Organization", t => t.OrganizationId)
                .Index(t => t.CategoryId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Donate",
                c => new
                    {
                        DonateId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(precision: 18, scale: 0),
                        CreateDate = c.DateTime(),
                        Status = c.Boolean(),
                        PaymentId = c.Int(),
                        CustomerId = c.Int(),
                        FundId = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DonateId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Fund", t => t.FundId)
                .ForeignKey("dbo.Payment", t => t.PaymentId)
                .Index(t => t.PaymentId)
                .Index(t => t.CustomerId)
                .Index(t => t.FundId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        PassWord = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        BirthDay = c.DateTime(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(maxLength: 250, unicode: false),
                        Address = c.String(maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Comtact",
                c => new
                    {
                        IdMessage = c.Int(nullable: false, identity: true),
                        Phone = c.String(maxLength: 20, unicode: false),
                        Message = c.String(unicode: false, storeType: "text"),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        Address = c.String(maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdMessage);
            
            CreateTable(
                "dbo.Faq",
                c => new
                    {
                        FaqId = c.Int(nullable: false, identity: true),
                        Question = c.String(unicode: false, storeType: "text"),
                        Answered = c.String(unicode: false, storeType: "text"),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.FaqId);
            
            CreateTable(
                "dbo.ImageGallery",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        MoreImage = c.String(storeType: "xml"),
                        DisplayOrder = c.Int(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Partner",
                c => new
                    {
                        PartnerId = c.String(nullable: false, maxLength: 50, unicode: false),
                        PartnerName = c.String(maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        Image = c.String(maxLength: 500, unicode: false),
                        Address = c.String(maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.PartnerId);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Image = c.String(storeType: "xml"),
                        Description = c.String(maxLength: 500, unicode: false),
                        DisplayOrder = c.Int(),
                        Url = c.String(maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.SliderId);
            
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        VolunteersId = c.Int(nullable: false, identity: true),
                        VolunteersName = c.String(maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        Address = c.String(maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        Image = c.String(maxLength: 500),
                        BirthDay = c.DateTime(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.VolunteersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fund", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Donate", "PaymentId", "dbo.Payment");
            DropForeignKey("dbo.Donate", "FundId", "dbo.Fund");
            DropForeignKey("dbo.Donate", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Fund", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Blog", "TagId", "dbo.Tag");
            DropIndex("dbo.Donate", new[] { "FundId" });
            DropIndex("dbo.Donate", new[] { "CustomerId" });
            DropIndex("dbo.Donate", new[] { "PaymentId" });
            DropIndex("dbo.Fund", new[] { "OrganizationId" });
            DropIndex("dbo.Fund", new[] { "CategoryId" });
            DropIndex("dbo.Blog", new[] { "TagId" });
            DropTable("dbo.Volunteer");
            DropTable("dbo.Slide");
            DropTable("dbo.Partner");
            DropTable("dbo.ImageGallery");
            DropTable("dbo.Faq");
            DropTable("dbo.Comtact");
            DropTable("dbo.Organization");
            DropTable("dbo.Payment");
            DropTable("dbo.Customer");
            DropTable("dbo.Donate");
            DropTable("dbo.Fund");
            DropTable("dbo.Category");
            DropTable("dbo.Tag");
            DropTable("dbo.Blog");
            DropTable("dbo.Admin");
        }
    }
}
