namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageGallery", "Name", c => c.String(maxLength: 250));
            AddColumn("dbo.ImageGallery", "TagId", c => c.Int());
            CreateIndex("dbo.ImageGallery", "TagId");
            AddForeignKey("dbo.ImageGallery", "TagId", "dbo.Tag", "TagId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageGallery", "TagId", "dbo.Tag");
            DropIndex("dbo.ImageGallery", new[] { "TagId" });
            DropColumn("dbo.ImageGallery", "TagId");
            DropColumn("dbo.ImageGallery", "Name");
        }
    }
}
