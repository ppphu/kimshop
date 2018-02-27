using KimShop.Data.Infrastructure;
using KimShop.Model.Models;

namespace KimShop.Data.Repositories
{
    public interface IAppRoleGroupRepository : IRepository<AppRoleGroup>
    {
    }

    public class AppRoleGroupRepository : Repository<AppRoleGroup>, IAppRoleGroupRepository
    {
        public AppRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}