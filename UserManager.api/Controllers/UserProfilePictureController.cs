using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.core.commands.user;

namespace UserManager.api.Controllers;

[ApiController]
[Route("profile-picture")]
public class UserProfilePictureController :BaseController
{
    public UserProfilePictureController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("", Name = nameof(UploadPhoto))]
    public async Task<IActionResult> UploadPhoto(ProfilePictureUploadRequest request)
    {
        return Ok();
    }
}
