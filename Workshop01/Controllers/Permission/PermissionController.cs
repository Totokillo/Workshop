

using Microsoft.AspNetCore.Mvc;
using Workshop01.BackEnd.Model.Function.Query.Permission;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Response.Permission;

namespace Workshop01.Controllers.Permission;

[ApiController]
[Route("[controller]")]
public class PermissionController : ApiControllerBase
    {
    [HttpPost("LoginPermission")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<LoginList>>> LoginPermission(LoginPermission command) => Ok(await Mediator.Send(command));
}

