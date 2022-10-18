using MediatR;

namespace UserManager.api.Controllers;

public class UserProfilePictureController :BaseController
{
    public UserProfilePictureController(IMediator mediator) : base(mediator)
    {
    }
}
