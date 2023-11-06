namespace FileSystem.Contracts
{
    //The file system
    public interface IFileSystem
    {
       IFileSystemDirectory Root { get;}

       IFileSystemItem? FindEntry(string path);

        IFileSystemDirectory RenameDirectory(string oldName, string newName);
    }
}