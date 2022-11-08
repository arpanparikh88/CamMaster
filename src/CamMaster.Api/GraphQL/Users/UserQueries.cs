using System.Security.Claims;
using CamMaster.Api.Server.Authentication;
using CamMaster.Api.Server.Models;

namespace CamMaster.Api.Server.GraphQL.Users;
[ExtendObjectType(typeof(Query))]

public class UserQueries
{
    private readonly IIdentityParser<UserAccount> _identityParser;

    public UserQueries(IIdentityParser<UserAccount> identityParser)
    {
        _identityParser = identityParser;
    }

    public async Task<UserAccount> GetMe(ClaimsPrincipal claimsPrincipal)
    {
        return _identityParser.Parse();
    }
}
