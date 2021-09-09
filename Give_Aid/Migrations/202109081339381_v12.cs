namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donate", "NameCard", c => c.String());
            AlterColumn("dbo.Donate", "CardNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donate", "CardNumber", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Donate", "NameCard", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
