﻿using KimShop.Data.Infrastructure;
using KimShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace KimShop.Data.Repositories
{
    public interface IAppGroupRepository : IRepository<AppGroup>
    {
        IEnumerable<AppGroup> GetListGroupByUserId(string userId);

        IEnumerable<AppUser> GetListUserByGroupId(int groupId);
    }

    public class AppGroupRepository : Repository<AppGroup>, IAppGroupRepository
    {
        public AppGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<AppGroup> GetListGroupByUserId(string userId)
        {
            var query = from g in DbContext.AppGroups
                        join ug in DbContext.AppUserGroups
                        on g.ID equals ug.GroupId
                        where ug.UserId == userId
                        select g;
            return query;
        }

        public IEnumerable<AppUser> GetListUserByGroupId(int groupId)
        {
            var query = from g in DbContext.AppGroups
                        join ug in DbContext.AppUserGroups
                        on g.ID equals ug.GroupId
                        join u in DbContext.Users
                        on ug.UserId equals u.Id
                        where ug.GroupId == groupId
                        select u;
            return query;
        }
    }
}