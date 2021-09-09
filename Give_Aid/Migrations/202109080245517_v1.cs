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
                    })
                .PrimaryKey(t => t.AboutId);
            
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Fund", "FundName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Fund", "Description", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Fund", "TargetAmount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            DropColumn("dbo.Fund", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fund", "Title", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Fund", "TargetAmount", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.Fund", "Description", c => c.String(unicode: false));
            AlterColumn("dbo.Fund", "FundName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Category", "CategoryName", c => c.String(maxLength: 250, unicode: false));
            DropTable("dbo.About");
        }
    }
}
