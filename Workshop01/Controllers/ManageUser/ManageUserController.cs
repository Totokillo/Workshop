


using Microsoft.AspNetCore.Mvc;
using Workshop01.BackEnd.Model.Function.Command.ManageUser;
using Workshop01.BackEnd.Model.Function.Query.ManageUser;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Response.ManageUser;

namespace Workshop01.Controllers.ManageUser;

[ApiController]
[Route("[controller]")]

public class ManageUserController : ApiControllerBase
    {
    [HttpPost("InsertManageUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<bool>>> InsertManageUser(InsertManageUser command) => Ok(await Mediator.Send(command));

    [HttpPost("SelectManageUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<ManageUserList>>> SelectManageUser(SelectManageUser command) => Ok(await Mediator.Send(command));

    [HttpPost("UpdateManageUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<bool>>> UpdateManageUser(UpdateManageUser command) => Ok(await Mediator.Send(command));

    [HttpPost("DeleteManageUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<bool>>> DeleteManageUser(DeleteManageUser command) => Ok(await Mediator.Send(command));

    [HttpPost("InsertCheckIn")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<bool>>> InsertCheckIn(InsertCheckIn command) => Ok(await Mediator.Send(command));

    [HttpPost("SelectCheckInTimeStamp")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponses<SelectCheckInList>>> SelectCheckInTimeStamp(SelectCheckInTimeStamp command) => Ok(await Mediator.Send(command));
}

