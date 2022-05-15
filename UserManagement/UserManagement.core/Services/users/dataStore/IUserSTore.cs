using asom.lib.core;
using UserManagement.core.shared;
using CommandResponse = asom.lib.core.CommandResponse;

namespace UserManagement.core.Services.users.dataStore;

public interface IUserStore
{
    Task<CommandResponse> CreateUser(AppUserEntity user);
    Task<CommandResponse<AppUserEntity>> GetUser(string userId);
    Task<PagedCommandResponse<IEnumerable<AppUserEntity>>> GetUser(PagedDataCriteria criteria);
}

public class AppUserEntity : EntityBase
{
    internal AppUserEntity()
    {
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

public class UserStoreFactory  : IUserStoreFactory
{
    private readonly AppConfig _appConfig;

    public UserStoreFactory(AppConfig appConfig)
    {
        _appConfig = appConfig;
    }

    public IUserStore GetStore() =>
        /*_appConfig.StorageOption.UseMemoryStore ? new UserMemoryStore() :*/ new UserFileStore();
}

public interface IUserStoreFactory
{
    IUserStore GetStore();
}
