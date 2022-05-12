using UserManagement.core.Services.users.dataStore;

namespace UserManagement.core.Services.users.model;

public record AppUser
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public AppUserEntity ToEntity()
    {
        return new AppUserEntity()
        {
            Email = Email,
            Id = Id,
            DateCreated = DateTimeOffset.Now,
            DateModified = DateTimeOffset.Now,
            FirstName = FirstName,
            LastName = LastName
        };
    }
}
