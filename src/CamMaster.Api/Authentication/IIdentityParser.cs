using System.Security.Claims;
using CamMaster.Api.Server.Models;

namespace CamMaster.Api.Server.Authentication;

public interface IIdentityParser<out TUser>
{
    TUser Parse();
}
/// <summary>
/// This class is used to neatly convert claims data to strong type
/// </summary>
public class JwtIdentityParser : IIdentityParser<UserAccount>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public JwtIdentityParser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public UserAccount Parse()
    {
        _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

        var principal = _httpContextAccessor.HttpContext.User.Identity;
        // Pattern matching 'is' expression
        // assigns "claims" if "principal" is a "ClaimsPrincipal"
        if (principal is ClaimsIdentity claims)
        {
            return new UserAccount()
            {
                Id = int.Parse(claims.Claims.FirstOrDefault(x => x.Type == "Id")?.Value ?? "0"),
                LastName = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value ?? "",
                FirstName = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value ?? "",
                Username = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? "",
                Roles = claims.Claims.Where(c => c.Type == ClaimTypes.Role).Select(e => e.Value).ToList()
            };
        }
        throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
    }
}
