using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.Cameras;

[ExtendObjectType(typeof(Query))]
public class CameraQueries
{
    [UsePaging(ConnectionName = "Cameras", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Camera> Cameras(CamMasterContext context, IResolverContext resolverContext)
    {
        return context.Cameras
            .Include(e => e.Unit).ThenInclude(e => e.SimCards).ThenInclude(e => e.Nvr);
    }
}
