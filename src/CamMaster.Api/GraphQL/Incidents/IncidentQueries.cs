using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;

namespace CamMaster.Api.Server.GraphQL.Incidents;

[ExtendObjectType(typeof(Query))]
public class IncidentQueries
{
    [UsePaging(ConnectionName = "Incidents", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Incident> Incidents(CamMasterContext context)
    {
        return context.Incidents;
    }
}
