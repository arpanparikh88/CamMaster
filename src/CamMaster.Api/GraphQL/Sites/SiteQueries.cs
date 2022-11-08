using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.Sites;

[ExtendObjectType(typeof(Query))]
public class SiteQueries
{
    /// <summary>
    /// Gets all sites, able to filter and sort
    /// </summary>
    /// <param name="context"></param>
    /// <returns>IEnumerable of Sites</returns>
    [UsePaging(ConnectionName = "Sites", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    //Do not use projection as some fields are added in an edge extension to calculate unit count and wont work with it on
    public IQueryable<Site> Sites(CamMasterContext context)
    {
        return context.Sites.Include(e => e.Units);
    }
    /// <summary>
    /// Gets a single site with a given site name
    /// </summary>
    /// <param name="siteName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    [UseProjection]
    public async Task<Site?> SiteByName(string siteName, [ScopedService] CamMasterContext context)
    {
        return await context.Sites.FirstOrDefaultAsync(s => s.Name.Equals(siteName));
    }

    /// <summary>
    /// Gets a single site with a given site name
    /// </summary>
    /// <param name="siteId"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    [UseProjection]
    public async Task<Site?> SiteById(int siteId, CamMasterContext context)
    {
        return await context.Sites.FirstOrDefaultAsync(s => s.Id == siteId);
    }
}