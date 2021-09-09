namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageGallery", "Image", c => c.String(maxLength: 500));
            AlterColumn("dbo.Donate", "NameCard", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Donate", "CardNumber", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donate", "CardNumber", c => c.String());
            AlterColumn("dbo.Donate", "NameCard", c => c.String());
            DropColumn("dbo.ImageGallery", "Image");
        }
    }
}
