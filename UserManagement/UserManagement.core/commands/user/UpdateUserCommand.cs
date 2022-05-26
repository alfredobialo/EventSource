using asom.lib.core;
using MediatR;
using UserManagement.core.Services.users;
using UserManagement.core.Services.users.reqRes;

namespace UserManagement.core.commands.user;

public record UpdateUserCommand(UserProfileNameUpdateRequest userData) : IRequest<CommandResponse>;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CommandResponse>
{
    private readonly IUserManagerCommand _userManagerCommand;

    public UpdateUserCommandHandler(IUserManagerCommand userManagerCommand)
    {
        _userManagerCommand = userManagerCommand;
    }

    public async Task<CommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userManagerCommand.UpdateProfileName(request.userData);
    }
}
