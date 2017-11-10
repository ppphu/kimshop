namespace KimShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private KimShopDbContext dbContext;

        public KimShopDbContext Init()
        {
            return dbContext ?? (dbContext = new KimShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}