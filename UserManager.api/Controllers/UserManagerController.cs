using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.core.commands.user;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

namespace UserManager.api.Controllers;

[ApiController]
[Route("user-manager")]
public class UserManagerController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserManagerController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var cmdResponse = await _mediator.Send(new GetUserCommand(new UserQueryRequest(id)));
        return cmdResponse.Success switch
        {
            true => Ok(cmdResponse),
            _ => BadRequest(cmdResponse)
        };

    }

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] UserListQueryRequest request) =>
        Ok(await _mediator.Send(new GetUsersCommand(request)));

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AppUser user)
    {
        // do validation on Service Layer
        var added = await _mediator.Send(new CreateUserCommand { User = user });

        if (added.Success)
        {
            var created = Created(string.Empty, added);
            return created;
        }

        return BadRequest(added);
    }


    [HttpPut("")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfileNameUpdateRequest userData)
    {
        var response = await _mediator.Send(new UpdateUserCommand(userData));

        return response.Success switch
        {
            true => Ok(response),
            _ => BadRequest(response)
        };
    }
}
