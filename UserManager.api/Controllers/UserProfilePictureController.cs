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
         var response =  new {
            success = true,
            meta =  new {
                user ="00001",
                images = new
                 {
                    size = "sm",
                    url = "http://123.233.1.33/images/sm/00001-img-9328d63267d3",
                    tag = "00001 profile picture, Alfred Picture, Obialo Picture, Alfred Obialo, 00001"
                }
            }
         };
        return Ok();
    }
}
