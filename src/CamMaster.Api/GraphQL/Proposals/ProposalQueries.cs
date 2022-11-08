using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.Proposals
{
    [ExtendObjectType(typeof(Query))]
    public class ProposalQueries
    {
        [UsePaging(ConnectionName = "Proposals", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Proposal> Proposals(CamMasterContext context)
        {
            return context.Proposals.Include(p => p.ProposalUnits);
        }

        [UsePaging(ConnectionName = "ProposalsByLeaseCount", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Proposal> ProposalsByLeaseCount(CamMasterContext context, string lease = "")
        {
            return context.Proposals.Include(p => p.ProposalUnits.Count(pr => pr.Lease == lease));

        }

        [UsePaging(ConnectionName = "ProposalsBySolarPanelCount", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Proposal> ProposalsBySolarPanelCount(CamMasterContext context, string solarPanel = "")
        {
            return context.Proposals.Include(p => p.ProposalUnits.Count(pr => pr.SolarPanel == solarPanel));

        }
    }
}
