using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        KimShopDbContext dbContext;
        public KimShopDbContext Init()
        {
            return dbContext ?? (dbContext = new KimShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext!=null)
            {
                dbContext.Dispose();
            }
        }
    }
}
