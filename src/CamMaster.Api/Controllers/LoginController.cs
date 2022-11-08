using System.Net;
using CamMaster.Api.Server.Authentication;
using CamMaster.Api.Server.GraphQL.Users;
using CamMaster.Api.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamMaster.Api.Server.Controllers;


public class LoginController : BaseApiController<LoginController>
{
    private readonly IAuthenticationService<UserAccount?, UserLoginInput> _authenticationService;
    private readonly ITokenService _tokenService;

    public LoginController(ILogger<LoginController> logger, IAuthenticationService<UserAccount?, UserLoginInput> authenticationService, ITokenService tokenService) : base(logger)
    {
        _authenticationService = authenticationService;
        _tokenService = tokenService;
    }

    [AllowAnonymous]
    [Route("authenticate")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserAccount>> GetToken(UserLoginInput loginRequest)
    {
        var existingUser = await _authenticationService.GetValidUser(loginRequest);

        if (existingUser == null) return Unauthorized();

        var token = await _tokenService.GenerateToken(existingUser);
        existingUser.Token = token;

        return Ok(existingUser);
    }
}
