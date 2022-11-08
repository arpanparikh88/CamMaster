using CamMaster.Api.Server.Authentication;
using CamMaster.Api.Server.GraphQL.Common;
using CamMaster.Api.Server.Models;
using CamMaster.Persistence.Context;
using Microsoft.AspNetCore.Authorization;

namespace CamMaster.Api.Server.GraphQL.Users;

[ExtendObjectType(typeof(Mutation))]
[AllowAnonymous]
public class UserMutations
{
    public async Task<UserLoginPayload> UserLogin(CamMasterContext dbContext, 
        [Service] IAuthenticationService<UserAccount?, UserLoginInput> authenticationService,
        [Service] ITokenService tokenService,UserLoginInput loginInput)
    {
        var existingUser = await authenticationService.GetValidUser(loginInput);

        if (existingUser == null) return new UserLoginPayload(new UserError("Unauthorized", "UnAUTH"));

        var token = await tokenService.GenerateToken(existingUser);
        existingUser.Token = token;

        return new UserLoginPayload(existingUser);
    }
}
