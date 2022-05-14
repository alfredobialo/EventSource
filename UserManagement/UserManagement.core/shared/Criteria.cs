namespace UserManagement.core.shared;

public class Criteria : ICriteria
{
    public string Query { get; set; }
    public string SortBy { get; set; }
    public string Id { get; set; }
}
