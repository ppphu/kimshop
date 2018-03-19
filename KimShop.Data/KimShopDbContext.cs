using KimShop.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace KimShop.Data
{
    public class KimShopDbContext : IdentityDbContext<AppUser>
    {
        public KimShopDbContext() : base("KimShopConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<Error> Errors { get; set; }

        public DbSet<AppGroup> AppGroups { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppRoleGroup> AppRoleGroups { get; set; }
        public DbSet<AppUserGroup> AppUserGroups { get; set; }

        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public static KimShopDbContext Create()
        {
            return new KimShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().ToTable("AppUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AppRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AppUserLogins");
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.RoleId, i.UserId }).ToTable("AppUserRoles");
        }
    }
}