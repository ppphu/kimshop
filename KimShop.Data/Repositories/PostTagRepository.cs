﻿using KimShop.Data.Infrastructure;
using KimShop.Model.Models;

namespace KimShop.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag>
    {
    }

    public class PostTagRepository : Repository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}