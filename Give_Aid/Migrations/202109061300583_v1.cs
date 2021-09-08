namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donate", "Content", c => c.String(maxLength: 250));
            AlterColumn("dbo.Fund", "TargetAmount", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.Fund", "CurentAmount", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.Donate", "Amount", c => c.Decimal(precision: 18, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donate", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.Fund", "CurentAmount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.Fund", "TargetAmount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            DropColumn("dbo.Donate", "Content");
        }
    }
}
