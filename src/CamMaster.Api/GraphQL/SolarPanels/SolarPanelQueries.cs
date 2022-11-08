using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.SolarPanels
{
    [ExtendObjectType(typeof(Query))]
    public class SolarPanelQueries
    {
        [UsePaging(ConnectionName = "SolarPanels", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SolarPanel> SolarPanels(CamMasterContext context)
        {
            return context.SolarPanels;
        }

        [UsePaging(ConnectionName = "SolarPanelsById", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SolarPanel> SolarPanelsById(CamMasterContext context, int id)
        {
            return context.SolarPanels.Where(e => e.Id == id);
        }
    }
}
