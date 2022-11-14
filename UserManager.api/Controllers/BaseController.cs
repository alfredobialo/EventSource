using asom.lib.core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.core.shared;

namespace UserManager.api.Controllers;

public class BaseController  : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    protected IActionResult BadCmd(object data) =>
        BadRequest(data);

    protected IActionResult NotFoundCmd(object data, string message = "Oops! data not found")
    {
        CommandResponse<object> response = CommandResponse<object>.FailedResponse(message ?? "Oops! data not found",
            StatusCodes.Status404NotFound);
        response.Data = data;
        return NotFound(response);
    }
    protected IActionResult OkCmd(object data, string message = "Successful")
    {
        CommandResponse<object> response = CommandResponse<object>.SuccessResponse(message ?? "success", data);
        return Ok(response);
    }
    protected IActionResult OkCmd<T>(T data, string message = "Successful")
    {
        CommandResponse<T> response = CommandResponse<T>.SuccessResponse(message ?? "success", data);
        return Ok(response);
    }
    protected IActionResult OkCmd()
    {
        CommandResponse response = CommandResponse.Successful("success");
        return Ok(response);
    } 
    
    protected IActionResult CreatedCmd(string message= "Created")
    {
        CommandResponse response = new CommandResponse() { Message = message ?? "Created", Code = StatusCodes.Status201Created};
        return Created("",response);
    } 
    
    protected IActionResult CreatedCmd<T>(T data, string message= "Created")
    {
        CommandResponse<T> response = new CommandResponse<T>() { Message = message ?? "Created",
            Code = StatusCodes.Status201Created, Data = data, Success = true
        };
        return Created("",response);
    }
}
