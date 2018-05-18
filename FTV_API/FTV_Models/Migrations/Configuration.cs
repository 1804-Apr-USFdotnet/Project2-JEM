using System.Data.Entity.Migrations;

namespace FTV.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FTVContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FTVContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}