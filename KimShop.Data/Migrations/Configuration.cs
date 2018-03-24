namespace KimShop.Data.Migrations
{
    using Common;
    using Model.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KimShop.Data.KimShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(KimShop.Data.KimShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Gõ lệnh update-data base để thực thi phương thức này.
            // Không cần lệnh add-migration trước vì đã set AutomaticMigrationsEnabled = true;
            CreateConfigTitle(context);

            CreateSlide(context);
        }

        private void CreateConfigTitle(KimShopDbContext context)
        {
            if (!context.SystemConfigs.Any(x => x.Code == "HomeTitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang chủ KimShop",
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang chủ KimShop",
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang chủ KimShop",
                });
            }
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

        private void CreateSlide(KimShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name = "Slide 1",
                        DisplayOrder = 1,
                        Status = true,
                        Url = "#",
                        Image = "/Assets/client/images/bag.jpg",
                        Description = @"<h2>FLAT 50% 0FF</h2>
                                        <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                                        <span class=""on-get"">GET NOW</span>"
                     },
                    new Slide() {
                        Name = "Slide 2",
                        DisplayOrder = 2,
                        Status = true,
                        Url = "#",
                        Image = "/Assets/client/images/bag1.jpg",
                    Description= @"<h2>FLAT 50% 0FF</h2>
                                    <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                                    <span class=""on-get"">GET NOW</span>"},
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}