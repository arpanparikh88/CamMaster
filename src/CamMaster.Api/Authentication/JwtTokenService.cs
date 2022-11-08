using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CamMaster.Api.Server.Models;
using Microsoft.IdentityModel.Tokens;

namespace CamMaster.Api.Server.Authentication;

public class JwtTokenService : ITokenService
{
    public async Task<string> GenerateToken(UserAccount user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim("Id", user.Id.ToString()),

            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.Exp,
                new DateTimeOffset(DateTime.Now.AddDays(1))
                    .ToUnixTimeSeconds().ToString())
        };

        claims.AddRange(user.Roles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("MySuperSecretKey")),
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = signingCredentials
        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return await Task.Run(() => tokenHandler.WriteToken(securityToken));
    }
}
