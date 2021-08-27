namespace Give_Aid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Volunteer", "VolunteersName", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Volunteer", "Email", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Volunteer", "Address", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Volunteer", "Phone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Volunteer", "BirthDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Volunteer", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteer", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Volunteer", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Volunteer", "Phone", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Volunteer", "Address", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Volunteer", "Email", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Volunteer", "VolunteersName", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
