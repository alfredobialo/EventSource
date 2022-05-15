using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.core.commands.user;
using UserManagement.core.Services.users;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

namespace UserManager.api.Controllers;

[ApiController]
[Route("user-manager")]
public class UserManagerController : ControllerBase
{
    private readonly IUserManagerQuery _userManagerQuery;
    private readonly IMediator _mediator;

    public UserManagerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id) =>
        Ok(await _mediator.Send(new GetUserCommand(new UserQueryRequest(id))));

    [HttpGet("")]
    public async Task<IActionResult> GetUsers([FromQuery] UserListQueryRequest request) =>
        Ok(await _mediator.Send(new GetUsersCommand(request)));

    [HttpPost("")]
    public async Task<IActionResult> CreateUser([FromBody] AppUser user)
    {
        // do validation on Service Layer
        var added = await _mediator.Send(new CreateUserCommand { User = user });

        if (added.Success)
        {
            return Ok(added);
        }

        return BadRequest(added);
    }
}
