using UserManagement.core.Services.users.dataStore;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;
using UserManagement.core.shared;

namespace UserManagement.core.Services.users.Impl;

public class UserManagerManager : IUserManagerCommand, IUserManagerQuery
{
    private readonly IUserStore _userStore;

    public UserManagerManager(IUserStore userStore)
    {
        _userStore = userStore;
    }
    public async Task<CommandResponse> AddUser(AppUser user)
    {
        AppUserEntity userEntity = user.ToEntity();
        var cmdResult  = await _userStore.CreateUser(userEntity);
        return cmdResult;
    }

    public Task<CommandResponse> UpdateProfileName(UserProfileNameUpdateRequest request)
    {
        return null;
    }

    public Task<AppUser> GetUser(UserQueryRequest query)
    {
        return Task.FromResult(new AppUser()
        {
            Email = "alfred@gmail.com",
            FirstName = "Alfred",
            LastName = "Obialo",
            Id = query.UserId
        });
    }

    public Task<IEnumerable<AppUser>> GetUsers(UserListQueryRequest query)
    {
        return null;
    }
}
