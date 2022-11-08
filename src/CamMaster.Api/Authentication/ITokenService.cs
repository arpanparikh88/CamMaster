using CamMaster.Api.Server.Models;

namespace CamMaster.Api.Server.Authentication;

public interface ITokenService
{
    Task<string> GenerateToken(UserAccount userAccount);
}
