namespace FileSystem.Contracts
{
    //Common contract for all items in the file system
    public interface IFileSystemItem
    {
        string Name { get; set; }

        DateTime CreationDate { get; }

        DateTime ModificationDate { get; set; }
    }
}

