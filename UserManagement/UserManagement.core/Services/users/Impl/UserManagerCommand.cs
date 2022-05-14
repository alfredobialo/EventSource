using UserManagement.core.Services.users.dataStore;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;
using UserManagement.core.shared;

namespace UserManagement.core.Services.users.Impl;

public class UserManagerManager : IUserManagerCommand, IUserManagerQuery
{
    private readonly IUserStore _userStore;

    public UserManagerManager(IUserStoreFactory storeFactory)
    {
        _userStore = storeFactory.GetStore();
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

    public async Task<AppUser> GetUser(UserQueryRequest query)
    {
        var entity = await _userStore.GetUser(query.UserId);
        if(entity.Success)
            return AppUser.FromEntity(entity.Data);

        return null;
    }

    public async Task<IEnumerable<AppUser>> GetUsers(UserListQueryRequest query)
    {
        var entity = await _userStore.GetUser(new Criteria()
        {
            Id = query.Key,
            Query = query.Query,
            SortBy = query.SortBy
        });
        if(entity.Success)
            return entity.Data.Select(x => AppUser.FromEntity(x));

        return new List<AppUser>();
    }
}
