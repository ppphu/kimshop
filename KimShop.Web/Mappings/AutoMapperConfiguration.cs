using AutoMapper;
using KimShop.Model.Models;
using KimShop.Web.Models;

namespace KimShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductTag, ProductTagViewModel>();

                cfg.CreateMap<PostViewModel, Post>();
                cfg.CreateMap<PostCategoryViewModel, PostCategory>();
                cfg.CreateMap<PostTagViewModel, PostTag>();
                cfg.CreateMap<TagViewModel, Tag>();

                cfg.CreateMap<MenuViewModel, Menu>();
                cfg.CreateMap<MenuGroupViewModel, MenuGroup>();

                cfg.CreateMap<Footer, FooterViewModel>();

                cfg.CreateMap<Slide, SlideViewModel>();

                cfg.CreateMap<Page, PageViewModel>();

                cfg.CreateMap<ContactDetail, ContactDetailViewModel>();

                cfg.CreateMap<AppGroup, AppGroupViewModel>();
                cfg.CreateMap<AppRole, AppRoleViewModel>();
                cfg.CreateMap<AppUser, AppUserViewModel>();
            });
        }
    }
}