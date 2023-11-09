namespace FileSystem;

public interface IFileSystemItem
{
    string Name { get; set; }
    DateTime CreationDate { get; }
    DateTime ModificationDate { get; set; }
}

public class File : IFileSystemItem
{
    public string Name { get; set; }
    public string Content { get; set; }
    
    public DateTime CreationDate { get; } = DateTime.UtcNow;
    
    public DateTime ModificationDate { get; set; } = DateTime.UtcNow;
}

public class Directory : IFileSystemItem
{
    public string Name { get; set; }
    
    public DateTime CreationDate { get; } = DateTime.UtcNow;
    public DateTime ModificationDate { get; set; } = DateTime.UtcNow;
    
    private List<IFileSystemItem> _items = new List<IFileSystemItem>();
    
    public IReadOnlyList<IFileSystemItem> Items => _items.AsReadOnly();

    public void AddItem(IFileSystemItem item)
    {
        if (_items.Any(i => i.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"An item with the name '{item.Name}' already exists in the directory '{Name}'.");
        }
        _items.Add(item);
        ModificationDate = DateTime.UtcNow; 
    }}
