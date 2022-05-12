using UserManagement.core.shared;

namespace UserManagement.core.Services.users.dataStore;

public interface IUserStore
{
    Task<CommandResponse> CreateUser(AppUserEntity user);
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

public abstract class EntityBase
{
    public string Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateModified { get; set; }
}
