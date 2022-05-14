namespace UserManagement.core.Services.users.reqRes;

public record UserProfileNameUpdateRequest
{
    public  string  UserId { get; set; }
    public  string  FirstName { get; set; }
    public  string  LastName { get; set; }
}
