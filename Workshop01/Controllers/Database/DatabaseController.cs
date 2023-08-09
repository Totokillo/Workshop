


using Microsoft.AspNetCore.Mvc;
using Workshop01.BackEnd.Model.Function.Database;
using Workshop01.BackEnd.Model.Response.Common;

namespace Workshop01.Controllers.Database;

[ApiController]
[Route("[controller]")]

public class DatabaseController : ApiControllerBase
    {
    [HttpPost("SetupDatabase")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<bool>>> SetupDatabase(SetupDatabase command) => Ok(await Mediator.Send(command));
    }

