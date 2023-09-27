using System.Linq.Expressions;
using asom.lib.core;
using UserManagement.core.shared;

namespace UserManagement.core.Services.users.dataStore;

public class AppUserEntity : EntityBase
{
    internal AppUserEntity()
    {
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateModified { get; set; }
}

