using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.Units;

[ExtendObjectType(typeof(Query))]
public class UnitQueries
{
    /// <summary>
    /// Gets all units, able to filter and sort
    /// </summary>
    /// <param name="context"></param>
    /// <returns>IQueryable of units</returns>
    [UsePaging(ConnectionName = "Units", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Unit> Units(CamMasterContext context)
    {
        return context.Units;
    }

    /// <summary>
    /// Gets all sites, able to filter and sort
    /// </summary>
    /// <param name="context"></param>
    /// <param name="siteName"></param>
    /// <returns>IEnumerable of Sites</returns>
    [UsePaging(ConnectionName = "UnitsBySiteName", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Unit> UnitsBySiteName(CamMasterContext context, string siteName = "")
    {
        return context.Units.Include(e => e.Site).Where(e => e.Site.Name == siteName);
    }

    [UsePaging(ConnectionName = "UnitsBySiteId", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Unit> UnitsBySiteId(CamMasterContext context, int siteId)
    {
        return context.Units
            .Include(e => e.Site).Where(e => e.Site.Id == siteId);
    }
}
