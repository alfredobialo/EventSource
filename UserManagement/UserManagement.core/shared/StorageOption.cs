namespace UserManagement.core.shared;

public class StorageOption
{
    public bool UseMemoryStore { get; set; }
    public string DirectoryName { get; set; } = "iData";
    public string DefaultExtension { get; set; } = ".json";

}
