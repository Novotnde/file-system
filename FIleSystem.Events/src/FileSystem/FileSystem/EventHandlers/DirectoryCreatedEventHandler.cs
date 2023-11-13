using FileSystem.Contracts;
using FileSystem.Events;
using FileSystem.Models;

namespace FileSystem.EventHandlers;

public class DirectoryCreatedEventHandler : IFileSystemEventHandler
{
    private readonly FileSystemDirectory _fileSystem;

    public DirectoryCreatedEventHandler(FileSystemDirectory fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IFileSystemItem? Handle(FileSystemEvent fileSystemEvent)
    {
        if (fileSystemEvent is DirectoryCreatedEvent createdEvent)
        {
            return _fileSystem.AddDirectory(createdEvent.Name);
        }

        return null;
    }
}