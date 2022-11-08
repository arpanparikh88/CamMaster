using Microsoft.AspNetCore.Mvc;

namespace CamMaster.Api.Server.Controllers;
[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
// [Authorize]
public abstract class BaseApiController<T> : ControllerBase
{
    protected readonly ILogger<T> Logger;

    protected BaseApiController(ILogger<T> logger)
    {
        Logger = logger;
    }
}

