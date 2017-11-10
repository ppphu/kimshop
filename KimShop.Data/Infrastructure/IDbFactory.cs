using System;

namespace KimShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KimShopDbContext Init();
    }
}