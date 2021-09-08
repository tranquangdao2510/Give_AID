namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donate", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.Donate", "NameCard", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Donate", "CardNumber", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donate", "CardNumber", c => c.String(maxLength: 200));
            AlterColumn("dbo.Donate", "NameCard", c => c.String(maxLength: 200));
            AlterColumn("dbo.Donate", "Amount", c => c.Decimal(precision: 18, scale: 0));
        }
    }
}
