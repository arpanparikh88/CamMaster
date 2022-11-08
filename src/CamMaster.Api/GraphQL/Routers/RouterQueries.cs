using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.Routers
{
    [ExtendObjectType(typeof(Query))]
    public class RouterQueries
    {
        [UsePaging(ConnectionName = "Routers", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Router> Routers(CamMasterContext context)
        {
            return context.Routers;
        }

        [UsePaging(ConnectionName = "RoutersById", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Router> RoutersById(CamMasterContext context, int id)
        {
            return context.Routers.Where(e => e.Id == id);
        }
    }
}
