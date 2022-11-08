using CamMaster.Persistence.Context;
using CamMaster.Persistence.Models;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.GraphQL.Contacts
{
    [ExtendObjectType(typeof(Query))]
    public class ContactQueries
    {
        [UsePaging(ConnectionName = "Contacts", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Contact> Contacts(CamMasterContext context)
        {
            return context.Contacts;
        }

        [UsePaging(ConnectionName = "ContactsByName", MaxPageSize = 100, IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Contact> ContactsByName(CamMasterContext context, string name = "")
        {
            return context.Contacts.Where(e => e.Name == name);
        }
    }
}
