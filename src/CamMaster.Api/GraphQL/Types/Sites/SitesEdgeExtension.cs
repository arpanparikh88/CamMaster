using CamMaster.Api.Server.GraphQL.Sites;
using CamMaster.Persistence.Models;
using HotChocolate.Types.Pagination;

namespace CamMaster.Api.Server.GraphQL.Types.Sites;


[ExtendObjectType(nameof(SiteQueries.Sites) + "Edge")]
public class SitesEdgeExtension
{
    public int TotalActiveUnits([Parent] Edge<Site> edge)
    {
        var result = edge.Node.Units.Count(e => e.Status == "Active");
        return result;
    }
}
