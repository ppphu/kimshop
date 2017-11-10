using KimShop.Data.Infrastructure;
using KimShop.Model.Models;

namespace KimShop.Data.Repositories
{
    public interface IPageRepository:IRepository<Page>
    {
    }

    public class PageRepository : Repository<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}