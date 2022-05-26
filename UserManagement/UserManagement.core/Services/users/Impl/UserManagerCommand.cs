using asom.lib.core;
using UserManagement.core.Services.users.dataStore;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

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

    public async Task<CommandResponse> UpdateProfileName(UserProfileNameUpdateRequest request)
    {
        return await  _userStore.UpdateUserName(request);
    }

    public async Task<CommandResponse<AppUser>> GetUser(UserQueryRequest query)
    {
        var entity = await _userStore.GetUser(query.UserId);
        if(entity.Success)
            return CommandResponse<AppUser>.SuccessResponse("",AppUser.FromEntity(entity.Data));

        return null;
    }

    public async Task<PagedCommandResponse<IEnumerable<AppUser>>> GetUsers(UserListQueryRequest query)
    {
        var entity = await _userStore.GetUser(new PagedDataCriteria()
        {
            Id = query.Key,
            Query = query.Query,
            SortBy = query.SortBy,
            PageSize = query.PageSize,
            CurrentPage = query.CurrentPage
        });
        if (entity.Success)
        {
             var e = entity.Data
                 .OrderBy(x => x.FirstName)
                 .ThenBy(x =>x.LastName)
                 .Select(x => AppUser.FromEntity(x));
             var newData = entity.Copy(e);
             return newData;
        }


        return new PagedCommandResponse<IEnumerable<AppUser>>();
    }
}
