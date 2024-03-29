﻿using asom.lib.core;
using Microsoft.Extensions.Logging;
using UserManagement.core.extensions;
using UserManagement.core.Services.users.dataStore;
using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;

namespace UserManagement.core.Services.users.Impl;

public class UserManagerManager : IUserManagerCommand, IUserManagerQuery
{
    private readonly ILogger<UserManagerManager> _logger;
    private readonly IUserStore _userStore;

    public UserManagerManager(IUserStoreFactory storeFactory, ILogger<UserManagerManager> logger)
    {
        _logger = logger;
        _userStore = storeFactory.GetStore();
    }

    public async Task<CommandResponse> AddUser(AppUser user)
    {
        AppUserEntity userEntity = user.ToEntity();

        _logger.LogInformation("Creating New User: {user}", user);
        var cmdResult = await _userStore.CreateUser(userEntity);
        _logger.LogWarning("Adding user action completed with result : {cmdResult}", cmdResult.ToJson());
        return cmdResult;
    }

    public async Task<CommandResponse> UpdateProfileName(UserProfileNameUpdateRequest request)
    {
        _logger.LogInformation("Updating User ProfileName :REQUEST  {request}", request);
        var result = await _userStore.UpdateUserName(request);
        // if operation was successful raise event of this operation
        _logger.LogWarning("Updating user Profile Name action completed with result : {result}", result.ToJson());
        return result;
    }

    public async Task<CommandResponse<AppUser>> GetUser(UserQueryRequest query)
    {
        var entity = await _userStore.GetUser(query.UserId);
        if (entity.Success)
        {
            _logger.LogInformation( "User Record Found: {entity}, Request data : {query} ", entity.ToJson(), query);
            return CommandResponse<AppUser>.SuccessResponse("", AppUser.FromEntity(entity.Data));
        }
        _logger.LogWarning( "User Record not Found FOR, Request data : {query} ",  query);
        return CommandResponse<AppUser>.FailedResponse(entity.Message);
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
                .ThenBy(x => x.LastName)
                .Select(x => AppUser.FromEntity(x));
            var newData = entity.Copy(e);
            return newData;
        }


        return new PagedCommandResponse<IEnumerable<AppUser>>();
    }
}
