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
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        PassWord = c.String(nullable: false, maxLength: 250, unicode: false),
                        Address = c.String(nullable: false, maxLength: 250, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                        BirthDay = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        GroupAdminId = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.GroupAdmin", t => t.GroupAdminId)
                .Index(t => t.GroupAdminId);
            
            CreateTable(
                "dbo.GroupAdmin",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        GroupAdminId = c.String(nullable: false, maxLength: 20),
                        RoleId = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.GroupAdminId, t.RoleId })
                .ForeignKey("dbo.GroupAdmin", t => t.GroupAdminId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.GroupAdminId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(nullable: false, maxLength: 250, unicode: false),
                        BlogImage = c.String(maxLength: 500, unicode: false),
                        TagId = c.Int(nullable: false),
                        Content = c.String(nullable: false, unicode: false, storeType: "text"),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.ImageGallery",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Image = c.String(maxLength: 500),
                        MoreImage = c.String(storeType: "xml"),
                        DisplayOrder = c.Int(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        TagId = c.Int(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Tag", t => t.TagId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Fund",
                c => new
                    {
                        FundId = c.String(nullable: false, maxLength: 50, unicode: false),
                        FundName = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(nullable: false, maxLength: 250, unicode: false),
                        Content = c.String(unicode: false),
                        FundImg = c.String(maxLength: 500, unicode: false),
                        TargetAmount = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurentAmount = c.Decimal(precision: 18, scale: 0),
                        CategoryId = c.Int(),
                        OrganizationId = c.Int(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
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
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 0),
                        NameCard = c.String(nullable: false, maxLength: 200),
                        CardNumber = c.String(nullable: false, maxLength: 200),
                        CreateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        PaymentId = c.Int(),
                        CustomerId = c.Int(),
                        FundId = c.String(maxLength: 50, unicode: false),
                        Content = c.String(nullable: false, maxLength: 500),
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
                        CustomerName = c.String(nullable: false, maxLength: 250, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        PassWord = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, maxLength: 250, unicode: false),
                        Phone = c.String(nullable: false, unicode: false),
                        BirthDay = c.DateTime(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(maxLength: 250),
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
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(nullable: false, maxLength: 200, unicode: false),
                        Address = c.String(nullable: false, maxLength: 200, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 200, unicode: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(),
                    })
                .PrimaryKey(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Comtact",
                c => new
                    {
                        IdMessage = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                        Address = c.String(nullable: false, unicode: false, storeType: "text"),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdMessage);
            
            CreateTable(
                "dbo.Faq",
                c => new
                    {
                        FaqId = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, unicode: false),
                        Answered = c.String(nullable: false, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(),
                    })
                .PrimaryKey(t => t.FaqId);
            
            CreateTable(
                "dbo.Partner",
                c => new
                    {
                        PartnerId = c.Int(nullable: false, identity: true),
                        PartnerName = c.String(nullable: false, maxLength: 250, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Image = c.String(maxLength: 500, unicode: false),
                        Address = c.String(nullable: false, maxLength: 250, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 200, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(),
                    })
                .PrimaryKey(t => t.PartnerId);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Image = c.String(storeType: "xml"),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        DisplayOrder = c.Int(),
                        Url = c.String(nullable: false, maxLength: 250, unicode: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SliderId);
            
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        VolunteersId = c.Int(nullable: false, identity: true),
                        VolunteersName = c.String(nullable: false, maxLength: 250, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Address = c.String(nullable: false, maxLength: 250, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Image = c.String(maxLength: 500),
                        BirthDay = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(maxLength: 250),
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
            DropForeignKey("dbo.ImageGallery", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Blog", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Permission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Permission", "GroupAdminId", "dbo.GroupAdmin");
            DropForeignKey("dbo.Admin", "GroupAdminId", "dbo.GroupAdmin");
            DropIndex("dbo.Donate", new[] { "FundId" });
            DropIndex("dbo.Donate", new[] { "CustomerId" });
            DropIndex("dbo.Donate", new[] { "PaymentId" });
            DropIndex("dbo.Fund", new[] { "OrganizationId" });
            DropIndex("dbo.Fund", new[] { "CategoryId" });
            DropIndex("dbo.ImageGallery", new[] { "TagId" });
            DropIndex("dbo.Blog", new[] { "TagId" });
            DropIndex("dbo.Permission", new[] { "RoleId" });
            DropIndex("dbo.Permission", new[] { "GroupAdminId" });
            DropIndex("dbo.Admin", new[] { "GroupAdminId" });
            DropTable("dbo.Volunteer");
            DropTable("dbo.Slide");
            DropTable("dbo.Partner");
            DropTable("dbo.Faq");
            DropTable("dbo.Comtact");
            DropTable("dbo.Organization");
            DropTable("dbo.Payment");
            DropTable("dbo.Customer");
            DropTable("dbo.Donate");
            DropTable("dbo.Fund");
            DropTable("dbo.Category");
            DropTable("dbo.ImageGallery");
            DropTable("dbo.Tag");
            DropTable("dbo.Blog");
            DropTable("dbo.Role");
            DropTable("dbo.Permission");
            DropTable("dbo.GroupAdmin");
            DropTable("dbo.Admin");
            DropTable("dbo.About");
        }
    }
}
