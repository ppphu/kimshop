namespace KimShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private KimShopDbContext dbContext;

        public UnitOfWork(IDbFactory factory)
        {
            dbFactory = factory;
        }

        public KimShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}