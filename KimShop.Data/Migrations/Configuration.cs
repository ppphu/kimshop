namespace KimShop.Data.Migrations
{
    using Common;
    using Model.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KimShop.Data.KimShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KimShop.Data.KimShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }

        private void CreateFooter(KimShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == Constants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                context.Footers.Add(new Footer()
                {
                    ID = Constants.DefaultFooterId,
                    Content = content
                });
                context.SaveChanges();
            }
        }
    }
}