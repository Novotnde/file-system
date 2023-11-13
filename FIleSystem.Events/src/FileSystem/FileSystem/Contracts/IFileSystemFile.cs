namespace FileSystem.Contracts;

public interface IFileSystemFile : IFileSystemItem
{
    string Content { get; set; }

    long Size { get; }
}