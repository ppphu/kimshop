using KimShop.Data.Infrastructure;
using KimShop.Model.Models;

namespace KimShop.Data.Repositories
{
    public interface IAppUserGroupRepository : IRepository<AppUserGroup>
    {
    }

    public class AppUserGroupRepository : Repository<AppUserGroup>, IAppUserGroupRepository
    {
        public AppUserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}