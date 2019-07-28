using System.Data.Entity.Migrations;
using Data.Models.Contexts;

namespace Data.Migrations
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
