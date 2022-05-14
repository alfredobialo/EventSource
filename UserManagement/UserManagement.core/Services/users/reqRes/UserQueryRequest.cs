namespace UserManagement.core.Services.users.reqRes;

public record UserQueryRequest(string UserId);

public class UserListQueryRequest
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string Query { get; set; } = "";
    public string SortBy { get; set; } = "name asc";
    public string Key { get; set; } = "";
}
