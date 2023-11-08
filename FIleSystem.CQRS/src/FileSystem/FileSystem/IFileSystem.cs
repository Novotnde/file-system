namespace FileSystem;

public interface IFileSystem
{
    void CreateFile(string directoryPath, string fileName, string content);
    void CreateDirectory(string parentDirectoryPath, string directoryName);
}

