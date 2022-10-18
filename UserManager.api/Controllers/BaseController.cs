using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserManager.api.Controllers;

public class BaseController  : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        this._mediator = mediator;
    }
}
