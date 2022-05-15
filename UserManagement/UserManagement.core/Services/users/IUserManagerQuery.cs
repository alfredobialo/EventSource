using asom.lib.core;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

namespace UserManagement.core.Services.users;

public interface IUserManagerQuery
{
    Task<CommandResponse<AppUser>> GetUser(UserQueryRequest query);
    Task<PagedCommandResponse<IEnumerable<AppUser>>> GetUsers(UserListQueryRequest query);
}