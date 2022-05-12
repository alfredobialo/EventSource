using UserManagement.core.shared;

namespace UserManagement.core.Services.users.dataStore;

public class UserMemoryStore : IUserStore
{
    public Task<CommandResponse> CreateUser(AppUserEntity user)
    {
        return null;
    }
}
