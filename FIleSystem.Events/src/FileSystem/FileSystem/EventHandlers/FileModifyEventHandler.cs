using FileSystem.Contracts;
using FileSystem.Events;
using FileSystem.Models;

namespace FileSystem.EventHandlers;

public class FileModifyEventHandler : IFileSystemEventHandler
{
    private readonly FileSystemDirectory _rootDirectory;

    public FileModifyEventHandler(FileSystemDirectory rootDirectory)
    {
        _rootDirectory = rootDirectory;
    }
    
    public IFileSystemItem? Handle(FileSystemEvent fileSystemEvent)
    {
        if (fileSystemEvent is FileModifyEvent createdEvent)
        {
           return _rootDirectory.RenameFile("file.txt", "newFile.txt");
        }
        return null;    
    }
}