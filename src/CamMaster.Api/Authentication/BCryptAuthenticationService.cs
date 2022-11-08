using CamMaster.Api.Server.GraphQL.Users;
using CamMaster.Api.Server.Models;
using CamMaster.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CamMaster.Api.Server.Authentication;


public class BCryptAuthenticationService : IAuthenticationService<UserAccount?, UserLoginInput>
{
    private readonly IDbContextFactory<CamMasterContext> _dbContextFactory;
    private const int BCryptHashWorkload = 7;
    public BCryptAuthenticationService(IDbContextFactory<CamMasterContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<UserAccount?> GetValidUser(UserLoginInput loginRequest)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        var user = await context.Users
            .Include(e => e.RoleUsers)
            .ThenInclude(e => e.Role)
            .FirstOrDefaultAsync(e => e.Username == loginRequest.Username);

        if (user == null) return null;

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(loginRequest.Password, BCryptHashWorkload);

        var verify = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);

        if (!verify) return null;

        return new UserAccount
        {
            Id = user.Id,
            Username = user.Username,
            LastName = user.LastName,
            FirstName = user.Name,
            Roles = user.RoleUsers.Select(e => e.Role.Name).ToList()
        };
    }
}
