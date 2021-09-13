namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comtact", "MetaTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comtact", "MetaTitle", c => c.String(maxLength: 250));
        }
    }
}
