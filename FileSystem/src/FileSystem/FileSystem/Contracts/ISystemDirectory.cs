
namespace FileSystem.Contracts
{
    //Contract for directories
    public interface IFileSystemDirectory : IFileSystemFile
    {
        IDictionary<string, IFileSystemItem> Items { get; }

        IFileSystemFile AddFile(string name, string content);

        IFileSystemDirectory AddDirectory(string name);

        IEnumerable<IFileSystemItem> GetAllItemsRecursive();

        IFileSystemFile RenameFile(string oldName, string newName);
    }
}

