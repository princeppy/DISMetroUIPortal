using System.Data.Entity.Migrations;
using JPY.DISMetroUIPortal.Migrations.SeedData;

namespace JPY.DISMetroUIPortal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DISMetroUIPortal.EntityFramework.DISMetroUIPortalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DISMetroUIPortal";
        }

        protected override void Seed(DISMetroUIPortal.EntityFramework.DISMetroUIPortalDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
