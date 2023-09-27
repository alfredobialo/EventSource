namespace UserManagement.core.shared;

public abstract class EntityBase_
{
    public string Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateModified { get; set; }
}
