using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

namespace UserManagement.core.Services.users;

public interface IUserManagerQuery
{
    Task<AppUser> GetUser(UserQueryRequest query);
    Task<IEnumerable<AppUser>> GetUsers(UserListQueryRequest query);
}