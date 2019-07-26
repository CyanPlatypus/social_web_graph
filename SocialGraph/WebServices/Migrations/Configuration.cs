using System.Data.Entity.Migrations;
using WebServices.Models.Contexts;

namespace WebServices.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SocialContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SocialContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
