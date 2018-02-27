namespace KimShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KimShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KimShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //CreateUser(context);
            //CreateSlide(context);
            //CreateProductCategorySample(context);
            //CreatePage(context);
        }

        private void CreateUser(KimShopDbContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new KimShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new KimShopDbContext()));

            var user = new AppUser()
            {
                UserName = "phu",
                Email = "ppphu1302@gmail.com",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName = "Phương Phong Phú",
               
            };
            if (manager.Users.Count(x => x.UserName == "phu") == 0)
            {
                manager.Create(user, "12345");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("ppphu1302@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            }
        }

        private void CreateProductCategorySample(KimShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> productCategories = new List<ProductCategory>()
                {
                    new ProductCategory() {Name="Điên lạnh", Alias="dien-lanh",Status=true },
                    new ProductCategory() {Name="Viễn thông", Alias="vien-thong",Status=true },
                    new ProductCategory() {Name="Đồ gia dụng", Alias="do-gia-dung",Status=true },
                    new ProductCategory() {Name="Mỹ phẩm", Alias="my-pham",Status=true },
                };
                context.ProductCategories.AddRange(productCategories);
                context.SaveChanges();
            }
        }

        private void CreateSlide(KimShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> slides = new List<Slide>()
                {
                    new Slide()
                    {
                        Name = "Slide 01",
                        DisplayOrder = 1,
                        Url= "#",
                        Image="/Assets/client/images/bag.jpg",
                        Status = true,
                        Description = @"<h2>GIẢM GIÁ 50%</h2>
								<label> CHO TẤT CẢ CÁC MẶT HÀNG <b>TRÊN ĐƠN HÀNG</b></label>
								<p> Nhân dịp ngày thứ 6 đen tối, giảm giá các mặt hàng trong tháng giảm giá </p>
								<span class=""on-get"">MUA NGAY</span>"
                    },
                    new Slide()
                    {
                        Name = "Slide 02",
                        DisplayOrder = 2,
                        Url = "#",
                        Image = "/Assets/client/images/bag1.jpg",
                        Status = true,
                        Description = @"<h2>GIẢM GIÁ 50%</h2>
								<label> CHO TẤT CẢ CÁC MẶT HÀNG <b>TRÊN ĐƠN HÀNG</b></label>
								<p> Nhân dịp ngày thứ 6 đen tối, giảm giá các mặt hàng trong tháng giảm giá </p>
								<span class=""on-get"">MUA NGAY</span>"
                    }
                };
                context.Slides.AddRange(slides);
                context.SaveChanges();
            }
        }

        private void CreatePage(KimShopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                var page = new Page()
                {
                    Name="First page",
                    Alias = "gioi-thieu",
                    Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium,
                                totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. 
                                Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui 
                                ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit,
                                sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam,
                                quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure
                                reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                    Status = true
                };
                context.Pages.Add(page);
                context.SaveChanges();
            }
        }
    }
}