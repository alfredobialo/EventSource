namespace UserManagement.core.shared;

public interface ICriteria
{
    string Query { get; set; }
    string SortBy { get; set; }
    string Id { get; set; }
}
