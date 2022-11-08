namespace CamMaster.Api.Server.Authentication;

public interface IAuthenticationService<TUser, in TInput>
{
    Task<TUser> GetValidUser(TInput loginRequest);
}
