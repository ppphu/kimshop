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
                cfg.CreateMap<PostViewModel, Post>();
                cfg.CreateMap<PostCategoryViewModel, PostCategory>();
                cfg.CreateMap<TagViewModel, Tag>();
                cfg.CreateMap<PostTagViewModel, PostTag>();
                cfg.CreateMap<MenuViewModel, Menu>();
                cfg.CreateMap<MenuGroupViewModel, MenuGroup>();
            });
        }
    }
}