namespace FileSystem;

public interface IFileSystem
{
    void CreateFile(string directoryPath, string fileName, string content);
    void CreateDirectory(string parentDirectoryPath, string directoryName);
    IFileSystemItem? FindItem(string path);
    IEnumerable<Directory> GetSubDirectories(string directoryPath);
}

