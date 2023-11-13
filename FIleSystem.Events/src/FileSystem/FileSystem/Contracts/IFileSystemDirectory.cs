using FileSystem.Contracts;

namespace FileSystem;

public interface IFileSystemDirectory : IFileSystemItem
{
    IDictionary<string, IFileSystemItem?> Items { get; }
    
    IFileSystemDirectory? AddDirectory(string name);
    
    IEnumerable<IFileSystemItem?> GetAllItemsRecursive();

    IFileSystemFile? AddFile(string name, string content);
}