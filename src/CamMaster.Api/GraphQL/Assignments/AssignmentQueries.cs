using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.Assignments;

[ExtendObjectType(typeof(Query))]
public class AssignmentQueries
{
    [Authorize(Roles = new[] { "Supervisor" })]
    [UsePaging(ConnectionName = "Assignments", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Station> Assignments(CamMasterContext context)
    {
        return context.Stations;
    }

    [UsePaging(ConnectionName = "AssignmentsByUnitId", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<StationUnit> AssignmentsByUnitId(CamMasterContext context, int id)
    {
        return context.StationUnits.Include(e => e.Unit)
            .Where(e => e.Id == id);
    }
}
