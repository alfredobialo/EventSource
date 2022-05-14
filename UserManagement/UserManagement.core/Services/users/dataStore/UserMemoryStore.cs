using UserManagement.core.shared;

namespace UserManagement.core.Services.users.dataStore;

public class UserMemoryStore : IUserStore
{
    public Task<CommandResponse> CreateUser(AppUserEntity user)
        => Task.FromResult(CommandResponse.Successful("User Created in Memory"));

    public Task<CommandResponse<AppUserEntity>> GetUser(string userId) =>
         Task.FromResult( CommandResponse<AppUserEntity>.Successful(new AppUserEntity()
        {
            Id = userId,
            FirstName = "Memory",
            LastName = "User"
        }, "Success from Memory Store"));


    public Task<CommandResponse<IEnumerable<AppUserEntity>>> GetUser(ICriteria criteria)=>
    Task.FromResult(CommandResponse<IEnumerable<AppUserEntity>>.Successful(new List<AppUserEntity>()));
}
