using KimShop.Data.Infrastructure;
using KimShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace KimShop.Data.Repositories
{
    public interface IAppRoleRepository : IRepository<AppRole>
    {
        IEnumerable<AppRole> GetListRoleByGroupId(int groupId);
    }

    public class AppRoleRepository : Repository<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<AppRole> GetListRoleByGroupId(int groupId)
        {
            var query = from g in DbContext.AppRoles
                        join ug in DbContext.AppRoleGroups
                        on g.Id equals ug.RoleId
                        where ug.GroupId == groupId
                        select g;
            return query;
        }
    }
}