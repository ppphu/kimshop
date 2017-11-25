namespace KimShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KimShop.Data.KimShopDbContext>
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
            CreateProductCategorySample(context);
        }

        private void CreateUser(KimShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new KimShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new KimShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                DateOfBirth = DateTime.Now,
                FullName = "Technology Education"
            };
            if (manager.Users.Count(x => x.UserName == "tedu") == 0)
            {
                manager.Create(user, "123654$");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("tedu.international@gmail.com");

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
    }
}