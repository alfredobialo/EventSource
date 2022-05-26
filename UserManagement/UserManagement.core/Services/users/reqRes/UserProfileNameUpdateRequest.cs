namespace UserManagement.core.Services.users.reqRes;

public record UserProfileNameUpdateRequest
{
    public  string  UserId { get; init; }
    public  string?  FirstName { get; init; }
    public  string?  LastName { get; init; }
}
