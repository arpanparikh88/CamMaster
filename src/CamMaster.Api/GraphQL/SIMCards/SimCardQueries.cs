using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.SIMCards
{
    [ExtendObjectType(typeof(Query))]
    public class SimCardQueries
    {
        [UsePaging(ConnectionName = "SimCards", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SimCard> SimCards(CamMasterContext context)
        {
            return context.SimCards;
        }

        [UsePaging(ConnectionName = "SimCardsByUnitSerialNumber", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SimCard> SimCardsByUnitSerialNumber(CamMasterContext context, string serialNumber = "")
        {
            return context.SimCards.Include(e => e.Unit)
                .Where(e => e.SerialNumber == serialNumber);
        }
    }

}
