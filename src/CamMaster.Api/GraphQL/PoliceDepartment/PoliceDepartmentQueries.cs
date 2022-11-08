using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.PoliceDepartment
{
    [ExtendObjectType(typeof(Query))]
    public class PoliceDepartmentQueries
    {
        [UsePaging(ConnectionName = "PoliceDepartments", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Persistence.Models.PoliceDepartment> PoliceDepartments(CamMasterContext context)
        {
            return context.PoliceDepartments;
        }
    }
}
