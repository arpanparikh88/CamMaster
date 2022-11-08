using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.AirCards;

[ExtendObjectType(typeof(Query))]
public class AirCardQueries
{
    [UsePaging(ConnectionName = "AirCards", MaxPageSize = 100, IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<AirCard> AirCards(CamMasterContext context)
    {
        return context.AirCards;
    }
}
