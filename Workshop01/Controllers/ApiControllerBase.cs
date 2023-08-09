using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Workshop01.Controllers;

[ApiController]
[Route("[controller]")]

public abstract class ApiControllerBase : ControllerBase
    {
    private ISender _mediator = null;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }

