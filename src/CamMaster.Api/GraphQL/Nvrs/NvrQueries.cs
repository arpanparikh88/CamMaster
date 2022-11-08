using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;

namespace CamMaster.Api.Server.GraphQL.Nvrs;

[ExtendObjectType(typeof(Query))]

public class NvrQueries
{
    [UsePaging(ConnectionName = "Nvrs", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Nvr> Nvrs(CamMasterContext context)
    {
        return context.Nvrs;
    }
}
