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
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Admins.AddOrUpdate(
              new Admin {AdminId=1 ,AdminName = "admin", PassWord = "admin1234", CreatedDate = DateTime.Now, Status =true }
            );
        }
    }
}
