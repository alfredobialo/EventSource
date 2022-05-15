using asom.lib.core;
using MediatR;
using UserManagement.core.Services.users;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

namespace UserManagement.core.commands.user;

public record GetUserCommand  : IRequest<CommandResponse<AppUser>>
{
    public GetUserCommand(UserQueryRequest queryRequest)
    {
        QueryRequest = queryRequest;
    }
    public UserQueryRequest QueryRequest { get; set; }
}
public record GetUsersCommand  : IRequest<PagedCommandResponse<IEnumerable<AppUser>>>
{
    public GetUsersCommand(UserListQueryRequest queryRequest)
    {
        QueryRequest = queryRequest;
    }
    public UserListQueryRequest QueryRequest { get; set; }
}

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, CommandResponse<AppUser>>,
    IRequestHandler<GetUsersCommand, PagedCommandResponse<IEnumerable<AppUser>>>
{
    private readonly IUserManagerQuery _userManagerQuery;

    public GetUserCommandHandler(IUserManagerQuery userManagerQuery)
    {
        _userManagerQuery = userManagerQuery;
    }

    public async Task<CommandResponse<AppUser>> Handle(GetUserCommand request, CancellationToken cancellationToken) =>
        await _userManagerQuery.GetUser(request.QueryRequest);

    public async Task<PagedCommandResponse<IEnumerable<AppUser>>> Handle(GetUsersCommand request, CancellationToken cancellationToken) =>
        await _userManagerQuery.GetUsers(request.QueryRequest);
}
