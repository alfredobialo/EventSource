using Microsoft.AspNetCore.Mvc;
using UserManagement.core.Services.users;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

namespace UserManager.api.Controllers;

[ApiController]
[Route("user-manager")]
public class UserManagerController : ControllerBase
{

    private readonly IUserManagerQuery _userManagerQuery;
    private readonly IUserManagerCommand _userManagerCommand;

    public UserManagerController(IUserManagerQuery userManagerQuery, IUserManagerCommand userManagerCommand)
    {
        _userManagerQuery = userManagerQuery;
        _userManagerCommand = userManagerCommand;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        return Ok(await _userManagerQuery.GetUser(new UserQueryRequest(id)));
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsers([FromQuery] UserListQueryRequest request)
        =>  Ok(await _userManagerQuery.GetUsers(request));

    [HttpPost("")]
    public async Task<IActionResult> CreateUser([FromBody] AppUser user)
    {
        // do validation on Service Layer
        var added = await _userManagerCommand.AddUser(user);

        if (added.Success)
        {
            return Ok(added);
        }

        return BadRequest(added);
    }
}
