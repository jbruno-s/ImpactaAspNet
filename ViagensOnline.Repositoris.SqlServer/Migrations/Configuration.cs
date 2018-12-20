namespace ViagensOnline.Repositoris.SqlServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ViagensOnline.Repositoris.SqlServer.ViagensOnlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ViagensOnline.Repositoris.SqlServer.ViagensOnlineDbContext";
        }

        protected override void Seed(ViagensOnline.Repositoris.SqlServer.ViagensOnlineDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
