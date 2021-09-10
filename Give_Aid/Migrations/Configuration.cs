namespace Give_Aid.Migrations
{
    using Give_Aid.Models.DataAccess;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Give_Aid.Models.DataAccess.NgoEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Give_Aid.Models.DataAccess.NgoEntity context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Admins.AddOrUpdate(
            
            //  new Admin { AdminName = "admin" ,PassWord="123456",Address="ha nam",Email="anhdao@gmail.com",Phone="0987654456", }
            //);
            //
        }
    }
}
