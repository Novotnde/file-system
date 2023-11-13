namespace FileSystem.Contracts;

public interface IFileSystemItem
{
    string Name { get; }

    DateTime CreationDate { get; }

    DateTime ModificationDate { get; }
}