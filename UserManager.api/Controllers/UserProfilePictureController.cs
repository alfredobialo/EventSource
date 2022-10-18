using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserManager.api.Controllers;

[ApiController]
[Route("profile-picture")]
public class UserProfilePictureController :BaseController
{
    public UserProfilePictureController(IMediator mediator) : base(mediator)
    {
    }
}
