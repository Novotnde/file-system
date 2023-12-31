using FileSystem.Contracts;

namespace FileSystem.Models;

public class FileSystemFile : IFileSystemFile
{
    public string Name { get; set; }
    
    public DateTime CreationDate { get; }
    
    public DateTime ModificationDate { get; private set; }
    
    public string Content { get; set; }
    public long Size { get; }
    
    public FileSystemFile(string name, string content)
    {
        Name = name;
        Content = content;
        ModificationDate = DateTime.UtcNow;
        CreationDate = DateTime.UtcNow;
    }

    public IFileSystemItem Rename(string newName)
    {
        Name = newName;
        ModificationDate = DateTime.UtcNow;
        return this;
    }
}