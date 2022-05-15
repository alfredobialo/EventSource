using asom.lib.core;
using MediatR;
using UserManagement.core.Services.users;
using UserManagement.core.Services.users.model;

namespace UserManagement.core.commands.user;

public record CreateUserCommand  : IRequest<CommandResponse>
{
    public AppUser User { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CommandResponse>
{
    private readonly IUserManagerCommand _userManagerCommand;

    public CreateUserCommandHandler(IUserManagerCommand userManagerCommand)
        => _userManagerCommand = userManagerCommand;

    public async Task<CommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        => await  _userManagerCommand.AddUser(request.User);
}
